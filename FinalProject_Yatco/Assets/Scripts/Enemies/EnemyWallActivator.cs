using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWallActivator : MonoBehaviour
{
    public GameObject EnemyWall;

    public GameObject WallSignal1;

    public GameObject WallSignal2;

    public bool isCooldownActive = false;

    public float wallCooldownTime;

    public float wallActiveTime;

    public Renderer wallSignalRenderer1;

    public Renderer wallSignalRenderer2;

    // Start is called before the first frame update
    void Start()
    {
        isCooldownActive = false;
        wallCooldownTime = Random.Range(3f, 8f);
        wallActiveTime = Random.Range(4f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCooldownActive)
        {
            EnemyWall.gameObject.SetActive(true);
            wallSignalRenderer1.material.color = Color.red;
            wallSignalRenderer2.material.color = Color.red;
            StartCoroutine(ActiveTimer());
        }
        else if (isCooldownActive)
        {
            EnemyWall.gameObject.SetActive(false);
            wallSignalRenderer1.material.color = Color.green;
            wallSignalRenderer2.material.color = Color.green;
            StartCoroutine(CooldownTimer());
        }
        
    }

    private IEnumerator CooldownTimer()
    {
        isCooldownActive = true;

        float elapsedTime = 0f;

        while (elapsedTime < wallCooldownTime)
        {
            yield return new WaitForSeconds(1f);
            elapsedTime += 1f;
        }

        isCooldownActive = false;
    }

    private IEnumerator ActiveTimer()
    {
        isCooldownActive = false;

        float elapsedTime = 0f;

        while (elapsedTime < wallCooldownTime)
        {
            yield return new WaitForSeconds(1f);
            elapsedTime += 1f;
        }

        isCooldownActive = true;
    }
}
