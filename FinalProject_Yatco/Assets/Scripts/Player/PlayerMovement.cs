using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float currentSpeed = 0;

    // Update is called once per frame
    void LateUpdate()
    {
        // Check if the W key is pressed
        if (Input.GetKey(KeyCode.W))
        {
            float translation = speed * Time.deltaTime;

            transform.Translate(0, 0, translation);
            currentSpeed = translation;
        }
    }
}