using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    GameObject[] agents;

    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("AI");
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void ClickToMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {
                foreach (GameObject ai in agents)
                {
                    ai.GetComponent<AIControl>().agent.SetDestination(hit.point);
                }
            }
        }
    }

    void FollowPlayer()
    {
        foreach (GameObject ai in agents)
            ai.GetComponent<AIControl>().agent.SetDestination(playerTransform.position);
    }
}
