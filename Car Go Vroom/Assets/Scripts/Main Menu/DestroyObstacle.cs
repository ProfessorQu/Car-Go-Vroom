using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    private void Update() {
        if (transform.position.y < -25f) {
            Destroy(gameObject);
        }
    }
}
