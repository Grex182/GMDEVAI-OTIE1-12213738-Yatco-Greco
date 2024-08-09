using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    [SerializeField] Transform[] Points;

    public float moveSpeed;

    private int pointsIndex;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(10.0f, 25.0f);
        transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsIndex <= Points.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime); //Go to target

            if (transform.position == Points[pointsIndex].transform.position)
            {
                pointsIndex += 1; //add 1 to pointsIndex if gameObject has reached target
            }

            if (pointsIndex == Points.Length)
            {
                pointsIndex = 0; //to reset the loop
            }
        }
    }
}
