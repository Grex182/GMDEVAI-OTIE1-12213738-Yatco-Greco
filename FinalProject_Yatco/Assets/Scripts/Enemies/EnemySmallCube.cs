using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySmallCube : MonoBehaviour
{
    private NavMeshAgent nav;

    public GameObject EnemySmallCubeGoal;

    public float enemySmallCubeMovementCooldown = 10f;

    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CooldownTimer());

        if (isMoving)
        {
            nav.destination = EnemySmallCubeGoal.transform.position;
        }
    }

    private IEnumerator CooldownTimer()
    {
        float elapsedTime = 0f;

        while (elapsedTime < enemySmallCubeMovementCooldown)
        {
            yield return new WaitForSeconds(1f);
            elapsedTime += 1f;
        }

        isMoving = true;
    }
}
