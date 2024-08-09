using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFollowPath : MonoBehaviour
{
    GameManager gM;

    Transform goal;
    public float speed = 8.0f;
    float accuracy = 1.0f;
    float rotSpeed = 2.0f;
    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWaypointIndex = 0;
    Graph graph;

    void Awake()
    {
        gM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>(); //get GameManager GameObject on the start of the Scene
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(8.0f, 16.0f);
        wps = wpManager.GetComponent<EnemyWaypointManager>().waypoints;
        graph = wpManager.GetComponent<EnemyWaypointManager>().graph;
        if (graph == null || wps == null || wps.Length < 2)
        {
            Debug.LogError("Waypoint Manager or Waypoints are not set up properly.");
            return;
        }
        currentNode = wps[0]; //it will go to element 0 first
        GoToFirstWayPoint();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (graph.getPathLength() == 0 || currentWaypointIndex == graph.getPathLength())
        {
            Debug.Log("getPathLength was 0");
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyWaypoint"))
        {
            Debug.Log("EnemySphere hit waypoint");

            //START OF LOOP
            if (currentNode == wps[1]) //if EnemySphere is already on the waypoint, go back to element 0
            {
                graph.AStar(currentNode, wps[0]);
                currentWaypointIndex = 0;
            }
            else //if not, proceed to element 1
            {
                graph.AStar(currentNode, wps[1]);
                currentWaypointIndex = 0;
            }
            //END OF LOOP
        }

        if (other.gameObject.CompareTag("Player"))
        {
            gM.playerDead = true;
            Debug.Log("Player got hit by EnemySphere");
        }
    }

    void GoToFirstWayPoint()
    {
        bool pathFound = graph.AStar(currentNode, wps[0]);
        if (!pathFound)
        {
            Debug.LogError("Path not found. Ensure waypoints and graph are correctly set up.");
        }
        currentWaypointIndex = 0;
    }
}