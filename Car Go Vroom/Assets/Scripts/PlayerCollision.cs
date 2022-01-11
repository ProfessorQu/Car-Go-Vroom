using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerMovement movement;

    private void Start() {
        movement = GetComponent<PlayerMovement>();
    }

	private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("KillObstacle"))
        {
            movement.enabled = false;

            Game_Manager.instance.EndGame();
        }
    }
}
