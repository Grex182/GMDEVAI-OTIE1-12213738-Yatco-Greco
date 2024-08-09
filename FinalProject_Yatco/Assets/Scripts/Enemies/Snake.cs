using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Snake : MonoBehaviour
{
    private NavMeshAgent nav;

    public GameObject snakeGoal1;

    public GameObject snakeGoal2;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.destination = snakeGoal1.transform.position;
        snakeGoal2.gameObject.SetActive(false);
    }

    // Update is called once per frame
/*    void Update()
    {
        
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SnakeGoal1"))
        {
            snakeGoal2.gameObject.SetActive(true);
            nav.destination = snakeGoal2.transform.position;
            snakeGoal1.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("SnakeGoal2"))
        {
            snakeGoal1.gameObject.SetActive(true);
            nav.destination = snakeGoal1.transform.position;
            snakeGoal2.gameObject.SetActive(false);
        }
    }
}
