using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleMovement : MonoBehaviour
{
    public Transform goal;
    public float speed = 0f;
    public float rotSpeed = 1f;

    public float acceleration = 5f;

    public float deceleration = 5f;

    public float minSpeed = 0f;

    public float maxSpeed = 20f;

    public float breakAngle = 20f;

    void Start()
    {

    }

    void LateUpdate()
    {
        /*Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
        Vector3 direction = lookAtGoal - this.transform.position;*/
        Vector3 direction = goal.position - this.transform.position; //uses position from the transform of goal instead to include all x, y, and z

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    Quaternion.LookRotation(direction),
                                                    Time.deltaTime * rotSpeed);

        //speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);

        if (Vector3.Angle(goal.forward, this.transform.forward) > breakAngle && speed > 2)
        {
            speed = Mathf.Clamp(speed - (deceleration * Time.deltaTime), minSpeed, maxSpeed);
        }
        else
        {
            speed = Mathf.Clamp(speed + (acceleration * Time.deltaTime), minSpeed, maxSpeed);
        }

        this.transform.Translate(0, 0, speed);

        if (Input.GetKeyDown("q"))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown("e"))
        {
            SceneManager.LoadScene(1);
        }
    }
}