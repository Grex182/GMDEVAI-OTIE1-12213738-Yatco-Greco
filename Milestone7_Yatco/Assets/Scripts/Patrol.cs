using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NPCBaseFSM
{
    GameObject[] waypoints;

    int currentWaypoint;

    void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    /*    OnStateEnter is called when a transition starts and the state machine starts to evaluate this state*/
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWaypoint = Random.Range(0, waypoints.Length);
        Debug.Log($"currentWaypoint {currentWaypoint}");
    }

/*    OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks*/
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if (waypoints.Length == 0)
        {
            return;
        }

        if (Vector3.Distance(waypoints[currentWaypoint].transform.position,
                             NPC.transform.position) < accuracy)
        {
            currentWaypoint++;
            Debug.Log($"currentWaypoint {currentWaypoint}");
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = Random.Range(0, waypoints.Length);
                Debug.Log($"currentWaypoint {currentWaypoint}");
            }
        }

        //rotate
        var direction = waypoints[currentWaypoint].transform.position - NPC.transform.position;
        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation,
                                                  Quaternion.LookRotation(direction),
                                                  rotSpeed * Time.deltaTime);

        NPC.transform.Translate(0, 0, Time.deltaTime * speed);
    }

/*    OnStateExit is called when a transition ends and the state machine finishes evaluating this state*/
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
