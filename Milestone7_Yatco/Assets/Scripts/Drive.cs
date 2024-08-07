using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Drive : MonoBehaviour {

 	public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    public float healthPoints = 100.0f;

    public GameObject bullet;

    public GameObject turret;

    public TMP_Text healthPointsText;

    public TMP_Text GameOverText;

    void Start()
    {
        healthPointsText.text = "Health: " + healthPoints;
        GameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        Death();
    }

    void Move()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }

    void Fire()
    {
        GameObject b = Instantiate(bullet, turret.transform.position, turret.transform.rotation);
        Physics.IgnoreCollision(b.GetComponent<Collider>(), this.GetComponent<Collider>());
        b.GetComponent<Rigidbody>().AddForce(turret.transform.forward * 500);
    }

    void Death()
    {
        if (healthPoints <= 0)
        {
            healthPoints = 0;
            GameOverText.gameObject.SetActive(true);
            Destroy(this.gameObject);
            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            healthPoints -= 10;
            healthPointsText.text = "Health: " + healthPoints;
            Debug.Log("Player hit");
        }
    }
}
