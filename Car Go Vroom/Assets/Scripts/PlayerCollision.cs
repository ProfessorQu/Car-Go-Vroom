using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerMovement movement;
    Rigidbody rb;

    private void Start() {
        movement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }

	private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("KillObstacle"))
        {
            FractureAble fract = other.collider.GetComponent<FractureAble>();
            fract.Hit(other.GetContact(0).point);
            
            movement.enabled = false;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
