using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject wpManager;
    GameObject[] wps;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void GoToHelipad()
    {
        agent.SetDestination(wps[1].transform.position);
/*        wpTarget = wps[1]; //takes note of what waypoint the tank is going to
        if (wpTarget == currentNode) //if tank is already on the targeted waypoint, then tank no move
        {
            Debug.Log("Disabling tank since already in destination");
        }
        else //if not, then go to targeted waypoint
        {
            graph.AStar(currentNode, wps[1]);
            currentWaypointIndex = 0;
            Debug.Log($"currentNode {currentNode}");
            Debug.Log($"currentWaypointIndex {currentWaypointIndex}");
        }*/
    }    

    public void GoToRuins()
    {
        agent.SetDestination(wps[7].transform.position);
/*        wpTarget = wps[7]; //takes note of what waypoint the tank is going to
        if (wpTarget == currentNode) //if tank is already on the targeted waypoint, then tank no move
        {
            Debug.Log("Disabling tank since already in destination");
        }
        else //if not, then go to targeted waypoint
        {
            graph.AStar(currentNode, wps[7]);
            currentWaypointIndex = 0;
            Debug.Log($"currentNode {currentNode}");
            Debug.Log($"currentWaypointIndex {currentWaypointIndex}");
        }*/
    }

    public void GoToFactory()
    {
        agent.SetDestination(wps[8].transform.position);
/*        wpTarget = wps[8]; //takes note of what waypoint the tank is going to
        if (wpTarget == currentNode) //if tank is already on the targeted waypoint, then tank no move
        {
            Debug.Log("Disabling tank since already in destination");
        }
        else //if not, then go to targeted waypoint
        {
            graph.AStar(currentNode, wps[8]); //wps[8] means element 8 in the waypoint manager
            currentWaypointIndex = 0;
            Debug.Log($"currentNode {currentNode}");
            Debug.Log($"currentWaypointIndex {currentWaypointIndex}");
        }*/
    }

    public void GoToTwinMountains()
    {
        agent.SetDestination(wps[3].transform.position);
/*        wpTarget = wps[3]; //takes note of what waypoint the tank is going to
        if (wpTarget == currentNode) //if tank is already on the targeted waypoint, then tank no move
        {
            Debug.Log("Disabling tank since already in destination");
        }
        else //if not, then go to targeted waypoint
        {
            graph.AStar(currentNode, wps[3]); //wps[3] means element 3 in the waypoint manager
            currentWaypointIndex = 0;
            Debug.Log($"currentNode {currentNode}");
            Debug.Log($"currentWaypointIndex {currentWaypointIndex}");
        }*/
    }

    public void GoToBarracks()
    {
        agent.SetDestination(wps[4].transform.position);
/*        wpTarget = wps[4]; //takes note of what waypoint the tank is going to
        if (wpTarget == currentNode) //if tank is already on the targeted waypoint, then tank no move
        {
            Debug.Log("Disabling tank since already in destination");
        }
        else //if not, then go to targeted waypoint
        {
            graph.AStar(currentNode, wps[4]); //wps[4] means element 4 in the waypoint manager
            currentWaypointIndex = 0;
            Debug.Log($"currentNode {currentNode}");
            Debug.Log($"currentWaypointIndex {currentWaypointIndex}");
        }*/
    }

    public void GoToCommandCenter()
    {
        agent.SetDestination(wps[13].transform.position);
/*        wpTarget = wps[13]; //takes note of what waypoint the tank is going to
        if (wpTarget == currentNode) //if tank is already on the targeted waypoint, then tank no move
        {
            Debug.Log("Disabling tank since already in destination");
        }
        else //if not, then go to targeted waypoint
        {
            graph.AStar(currentNode, wps[13]); //wps[13] means element 13 in the waypoint manager
            currentWaypointIndex = 0;
            Debug.Log($"currentNode {currentNode}");
            Debug.Log($"currentWaypointIndex {currentWaypointIndex}");
        }*/
    }

    public void GoToOilRefineryPumps()
    {
        agent.SetDestination(wps[6].transform.position);
/*        wpTarget = wps[6]; //takes note of what waypoint the tank is going to
        if (wpTarget == currentNode) //if tank is already on the targeted waypoint, then tank no move
        {
            Debug.Log("Disabling tank since already in destination");
        }
        else //if not, then go to targeted waypoint
        {
            graph.AStar(currentNode, wps[6]); //wps[6] means element 6 in the waypoint manager
            currentWaypointIndex = 0;
            Debug.Log($"currentNode {currentNode}");
            Debug.Log($"currentWaypointIndex {currentWaypointIndex}");
        }*/
    }

    public void GoToTankers()
    {
        agent.SetDestination(wps[15].transform.position);
/*        wpTarget = wps[15]; //takes note of what waypoint the tank is going to
        if (wpTarget == currentNode) //if tank is already on the targeted waypoint, then tank no move
        {
            Debug.Log("Disabling tank since already in destination");
        }
        else //if not, then go to targeted waypoint
        {
            graph.AStar(currentNode, wps[15]); //wps[15] means element 15 in the waypoint manager
            currentWaypointIndex = 0;
            Debug.Log($"currentNode {currentNode}");
            Debug.Log($"currentWaypointIndex {currentWaypointIndex}");
        }*/
    }

    public void GoToRadar()
    {
        agent.SetDestination(wps[17].transform.position);
/*        wpTarget = wps[17]; //takes note of what waypoint the tank is going to
        if (wpTarget == currentNode) //if tank is already on the targeted waypoint, then tank no move
        {
            Debug.Log("Disabling tank since already in destination");
        }
        else //if not, then go to targeted waypoint
        {
            graph.AStar(currentNode, wps[17]); //wps[20] means element 20 in the waypoint manager
            currentWaypointIndex = 0;
            Debug.Log($"currentNode {currentNode}");
            Debug.Log($"currentWaypointIndex {currentWaypointIndex}");
        }*/
    }

    public void GoToCommandPost()
    {
        agent.SetDestination(wps[16].transform.position);
/*        wpTarget = wps[16]; //takes note of what waypoint the tank is going to
        if (wpTarget == currentNode) //if tank is already on the targeted waypoint, then tank no move
        {
            Debug.Log("Disabling tank since already in destination");
        }
        else //if not, then go to targeted waypoint
        {
            graph.AStar(currentNode, wps[16]); //wps[19] means element 19 in the waypoint manager
            currentWaypointIndex = 0;
            Debug.Log($"currentNode {currentNode}");
            Debug.Log($"currentWaypointIndex {currentWaypointIndex}");
        }*/
    }

    public void GoToMiddleOfTheMap()
    {
        agent.SetDestination(wps[5].transform.position);
/*        wpTarget = wps[5]; //takes note of what waypoint the tank is going to
        if (wpTarget == currentNode) //if tank is already on the targeted waypoint, then tank no move
        {
            Debug.Log("Disabling tank since already in destination");
        }
        else //if not, then go to targeted waypoint
        {
            graph.AStar(currentNode, wps[5]); //wps[4] means element 4 in the waypoint manager
            currentWaypointIndex = 0;
            Debug.Log($"currentNode {currentNode}");
            Debug.Log($"currentWaypointIndex {currentWaypointIndex}");
        }*/
    }
}
