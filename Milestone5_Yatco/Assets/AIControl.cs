using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    NavMeshAgent agent;

    public GameObject target;

    public WASDMovement playerMovement;

    Vector3 wanderTarget;

    bool normalZombieWander = true;
    bool scaredZombieWander = true;
    bool evasiveZombieWander = true;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        playerMovement = target.GetComponent<WASDMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        /*        if (CanSeeTarget())
                {
                    CleverHide();
                }*/
        NormalZombie();
        ScaredZombie();
        EvasiveZombie();
    }

    void Flee(Vector3 location)
    {
        Vector3 fleeDirection = location - this.transform.position;
        agent.SetDestination(this.transform.position - fleeDirection);
    }

    void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    void Evade()
    {
        Vector3 targetDirection = target.transform.position - this.transform.position;

        float lookAhead = targetDirection.magnitude / (agent.speed + playerMovement.currentSpeed);

        Flee(target.transform.position + target.transform.forward * lookAhead);
    }

    void Wander()
    {
        float wanderRadius = 20f;
        float wanderDistance = 10f;
        float wanderJitter = 1f;

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter,
                                    0,
                                    Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(targetLocal);

        Seek(targetWorld);
    }

    void Hide()
    {
        float distance = Mathf.Infinity;
        Vector3 chosenSpot = Vector3.zero;

        int hidingSpotsCounts = World.Instance.GetHidingSpots().Length;

        for (int i = 0; i < hidingSpotsCounts; i++)
        {
            Vector3 hideDirection = World.Instance.GetHidingSpots()[i].transform.position - target.transform.position;
            Vector3 hidePosition = World.Instance.GetHidingSpots()[i].transform.position + hideDirection.normalized * 5; //distance offset

            float spotDistance = Vector3.Distance(this.transform.position, hidePosition);

            if (spotDistance < distance)
            {
                chosenSpot = hidePosition;
                distance = spotDistance;
            }
        }

        Seek(chosenSpot);
    }

    bool CanSeeTarget()
    {
        RaycastHit raycastInfo;
        Vector3 rayToTarget = target.transform.position - this.transform.position;
        if (Physics.Raycast(this.transform.position, rayToTarget, out raycastInfo))
        {
            return raycastInfo.transform.gameObject.tag == "Player";
        }
        Debug.Log($"A Zombie sees the player");
        return false;
    }

    void CleverHide()
    {
        float distance = Mathf.Infinity;
        Vector3 chosenSpot = Vector3.zero;
        Vector3 chosenDir = Vector3.zero;
        GameObject chosenGameObject = World.Instance.GetHidingSpots()[0];

        int hidingSpotsCounts = World.Instance.GetHidingSpots().Length;

        for (int i = 0; i < hidingSpotsCounts; i++)
        {
            Vector3 hideDirection = World.Instance.GetHidingSpots()[i].transform.position - target.transform.position;
            Vector3 hidePosition = World.Instance.GetHidingSpots()[i].transform.position + hideDirection.normalized * 5; //distance offset

            float spotDistance = Vector3.Distance(this.transform.position, hidePosition);

            if (spotDistance < distance)
            {
                chosenSpot = hidePosition;
                chosenDir = hideDirection;
                chosenGameObject = World.Instance.GetHidingSpots()[i];
                distance = spotDistance;
            }
        }

        Collider hideCol = chosenGameObject.GetComponent<Collider>();
        Ray back = new Ray(chosenSpot, -chosenDir.normalized);
        RaycastHit info;
        float rayDistance = 100.0f;
        hideCol.Raycast(back, out info, rayDistance);

        Seek(info.point + chosenDir.normalized * 5f);
    }

    void Pursue()
    {
        Vector3 targetDirection = target.transform.position - this.transform.position;

        float lookAhead = targetDirection.magnitude / (agent.speed + playerMovement.currentSpeed);

        Seek(target.transform.position + target.transform.forward * lookAhead);
    }

    void NormalZombie()
    {
        if (normalZombieWander && this.gameObject.CompareTag("Normal Zombie"))
        {
            Wander();
        }
        else if (!normalZombieWander && this.gameObject.CompareTag("Normal Zombie"))
        {
            Seek(target.transform.position);
        }
    }

    void ScaredZombie()
    {
        if (scaredZombieWander && this.gameObject.CompareTag("Scared Zombie"))
        {
            Wander();
        }
        else if (!scaredZombieWander && this.gameObject.CompareTag("Scared Zombie") || CanSeeTarget())
        {
            CleverHide();
        }
    }

    void EvasiveZombie()
    {
        if (evasiveZombieWander && this.gameObject.CompareTag("Evasive Zombie"))
        {
            Wander();
        }
        else if (!evasiveZombieWander && this.gameObject.CompareTag("Evasive Zombie"))
        {
            Evade();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("Normal Zombie"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                normalZombieWander = false;
                Debug.Log($"Normal Zombie Seeking Player");
            }
        }

        if (this.gameObject.CompareTag("Scared Zombie"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                scaredZombieWander = false;
                Debug.Log($"Scared Zombie Hiding From Player");
            }
        }

        if (this.gameObject.CompareTag("Evasive Zombie"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                evasiveZombieWander = false;
                Debug.Log($"Evasive Zombie Evading Player");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.CompareTag("Normal Zombie"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                normalZombieWander = true;
                Debug.Log($"Normal Zombie Back to Wandering Mode");
            }
        }

        if (this.gameObject.CompareTag("Scared Zombie"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                scaredZombieWander = true;
                Debug.Log($"Scared Zombie Back to Wandering Mode");
            }
        }

        if (this.gameObject.CompareTag("Evasive Zombie"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                evasiveZombieWander = true;
                Debug.Log($"Evasive Zombie Back to Wandering Mode");
            }
        }
    }
}
