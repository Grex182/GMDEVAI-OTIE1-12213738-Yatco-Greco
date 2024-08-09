using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrowdAI : MonoBehaviour
{
    GameObject[] goalLocations;

    NavMeshAgent agent;

    float speedMult;

    float detectionRadius = 20f;

    float fleeRadius = 10f;

    float flockRadius = 200f;

    public float navSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.CompareTag("Crowd1"))
        {
            goalLocations = GameObject.FindGameObjectsWithTag("CrowdGoal1");
        }
        else if (this.gameObject.CompareTag("Crowd2"))
        {
            goalLocations = GameObject.FindGameObjectsWithTag("CrowdGoal2");
        }
        agent = this.GetComponent<NavMeshAgent>();

        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
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

    void ResetAgent()
    {
        speedMult = Random.Range(1f, 2.5f);
        agent.speed = navSpeed * speedMult;
        agent.angularSpeed = 120f;
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
                agent.speed = 10f;
                agent.angularSpeed = 500f;
            }
        }
    }
}
