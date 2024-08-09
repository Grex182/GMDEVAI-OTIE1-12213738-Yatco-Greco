using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindWithTag("GameManager").GetComponent<GameManager>(); //get GameManager GameObject on the start of the Scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerGoal"))
        {
            gM.playerScore++;
            gM.playerHasScored = true;
            Debug.Log("Player Scored");
        }

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Crowd1") || other.gameObject.CompareTag("Crowd2"))
        {
            gM.playerDead = true;
            Debug.Log("Player got hit by EnemySphere");
        }
    }
}
