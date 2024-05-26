using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 12f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterMovement();
    }

    void CharacterMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); //input to move horizontally
        float moveZ = Input.GetAxis("Vertical"); //input to move vertically

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized; //enables movement but only through x and z axis, not up or bottom

        this.transform.Translate(moveDirection * speed * Time.deltaTime); //applies movement to player, multiplying Time.deltaTime with speed of player separates the frame rate from speed, so basically Time.deltaTime disables the fps thing in Update function if multiplied with something in it
    }
}
