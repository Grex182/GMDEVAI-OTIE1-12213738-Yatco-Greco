using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelForwardToGoal : MonoBehaviour
{

    public Transform goal;
    public float speed = 3;
    public float rotSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x, 
                                         this.transform.position.y, 
                                         goal.position.z);

        Vector3 direction = lookAtGoal - transform.position;

        //Slerp helps with a more natural rotation ig (SLERP = Spherical Linear Interpolation)
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                   Quaternion.LookRotation(direction),
                                                   Time.deltaTime * rotSpeed); //modifies character's rotation

        if (Vector3.Distance(lookAtGoal, transform.position) > 2.7) //if the character's position from the goal is greater than 1.8, keep moving and looking, else stop
        {
            /*transform.Translate(0, 0, speed * Time.deltaTime); //moving forward only*/
            this.transform.position = Vector3.Lerp(this.transform.position, goal.position, speed * Time.deltaTime); //replaced the other line of code with lerp but kept slerp at the top so is that okay or
        }
    }
}
