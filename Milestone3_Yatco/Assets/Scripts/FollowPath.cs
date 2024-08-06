using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    Transform goal;
    public float speed = 8.0f;
    float accuracy = 1.0f;
    float rotSpeed = 2.0f;
    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWaypointIndex = 0;
    Graph graph;
    GameObject wpTarget;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        graph = wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[0];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (graph.getPathLength() == 0 || currentWaypointIndex == graph.getPathLength())
        {
            return;
        }

        //the node we are closest to at the moment
        currentNode = graph.getPathPoint(currentWaypointIndex);

        //if we are close enough to the current waypoint, move to the next one
        if (Vector3.Distance(graph.getPathPoint(currentWaypointIndex).transform.position,
                             transform.position) < accuracy)
        {
            currentWaypointIndex++;
        }

        //IF WE ARE NOT AT THE END OF THE PATH
        if (currentWaypointIndex < graph.getPathLength())
        {
            goal = graph.getPathPoint(currentWaypointIndex).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                       Quaternion.LookRotation(direction),
                                                       Time.deltaTime * rotSpeed);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    public void GoToHelipad()
    {
        wpTarget = wps[1]; //takes note of what waypoint the tank is going to
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
        }
    }    

    public void GoToRuins()
    {
        wpTarget = wps[7]; //takes note of what waypoint the tank is going to
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
        }
    }

    public void GoToFactory()
    {
        wpTarget = wps[8]; //takes note of what waypoint the tank is going to
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
        }
    }

    public void GoToTwinMountains()
    {
        wpTarget = wps[3]; //takes note of what waypoint the tank is going to
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
        }
    }

    public void GoToBarracks()
    {
        wpTarget = wps[4]; //takes note of what waypoint the tank is going to
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
        }
    }

    public void GoToCommandCenter()
    {
        wpTarget = wps[13]; //takes note of what waypoint the tank is going to
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
        }
    }

    public void GoToOilRefineryPumps()
    {
        wpTarget = wps[6]; //takes note of what waypoint the tank is going to
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
        }
    }

    public void GoToTankers()
    {
        wpTarget = wps[15]; //takes note of what waypoint the tank is going to
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
        }
    }

    public void GoToRadar()
    {
        wpTarget = wps[17]; //takes note of what waypoint the tank is going to
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
        }
    }

    public void GoToCommandPost()
    {
        wpTarget = wps[16]; //takes note of what waypoint the tank is going to
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
        }
    }

    public void GoToMiddleOfTheMap()
    {
        wpTarget = wps[5]; //takes note of what waypoint the tank is going to
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
        }
    }
}
