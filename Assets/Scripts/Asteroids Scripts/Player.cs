using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab;

    public float turnSpeed = 1.0f;
    public float moveSpeed = 1.0f;
    private Rigidbody2D rb;

    private bool move;
    private float turning;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
        move = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turning = 1.0f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turning = -1.0f;
        }
        else
        {
            turning = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.J))
        {
            Shoot();
        }

    }

    private void FixedUpdate()
    {
        if(move)
        {
            rb.AddForce(this.transform.up * this.moveSpeed);

        }

        if(turning != 0.0f)
        {
            rb.AddTorque(turning * this.turnSpeed);
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Summon(this.transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.tag == "Asteroid")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager_Asteroids>().PlayerDied();
        }
    }
}
