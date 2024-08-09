using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBlockGoal : MonoBehaviour
{
    private NavMeshAgent nav;

    public GameObject playerGoal;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.destination = playerGoal.transform.position;
    }

    // Update is called once per frame
    /*    void Update()
        {

        }*/
}
