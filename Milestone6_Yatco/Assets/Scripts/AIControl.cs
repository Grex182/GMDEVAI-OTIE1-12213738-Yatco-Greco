using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    public GameObject goal;

    GameObject[] goalLocations;

    NavMeshAgent agent;

    Animator anim;

    float speedMult;

    float detectionRadius = 20f;

    float fleeRadius = 10f;

    float flockRadius = 15f;

    // Start is called before the first frame update
    void Start()
    {
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();

        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        anim.SetTrigger("isWalking");
        anim.SetFloat("wOffset", Random.Range(0.1f, 1f));
        ResetAgent();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 1)
        {
            ResetAgent();
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }

    void GoToGoal()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.transform.position);
    }

    void ResetAgent()
    {
        speedMult = Random.Range(0.1f, 1.5f);
        agent.speed = 2 * speedMult;
        agent.angularSpeed = 120f;
        anim.SetFloat("speedMultiplier", speedMult);
        anim.SetTrigger("isWalking");
        agent.ResetPath();
    }

    public void DetectNewObstacle(Vector3 location)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        {
            Vector3 fleeDirection = (this.transform.position - location).normalized;
            Vector3 newGoal = this.transform.position + fleeDirection * fleeRadius;

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newGoal, path);
            
            if (path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                anim.SetTrigger("isRunning");
                agent.speed = 10f;
                agent.angularSpeed = 500f;
            }
        }
    }

    public void DetectNewAttractingObstacle(Vector3 location)
    {
        if (Vector3.Distance(location, this.transform.position) < detectionRadius)
        {
            Vector3 flockDirection = (location - this.transform.position).normalized;
            Vector3 newGoal = this.transform.position + flockDirection * flockRadius;

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(newGoal, path);

            if (path.status != NavMeshPathStatus.PathInvalid)
            {
                agent.SetDestination(path.corners[path.corners.Length - 1]);
                anim.SetTrigger("isRunning");
                agent.speed = 10f;
                agent.angularSpeed = 500f;
            }
        }
    }
}
