using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    Rigidbody2D myRigidBody;
    PlayerMovement player;
    float xSpeed;

    void Start()
    {
        // Sets target bullet
        myRigidBody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        // Moves bullet across the screen
        myRigidBody.velocity = new Vector2(xSpeed, 0f);
    }

    // Kills enemies hit by the bullet
    void OnTriggerEnter2D(Collider2D other) {
        // Checks if bullet has hit an enemy
        if (other.tag == "Enemy") {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    // Destroys enemy game objects when they are hit by bullet
    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
