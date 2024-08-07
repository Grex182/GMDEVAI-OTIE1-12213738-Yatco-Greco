using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    public float healthPoints = 100.0f;

    Animator anim;

    public GameObject player;

    public GameObject bullet;

    public GameObject turret;

    public GameObject GetPlayer()
    {
        return player;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("health", healthPoints);

        if (player != null)
        {
            anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
        }

        if (healthPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        Physics.IgnoreCollision(b.GetComponent<Collider>(), this.GetComponent<Collider>());
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }

    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            healthPoints -= 10;
            Debug.Log("EnemyTank hit");
        }
    }
}
