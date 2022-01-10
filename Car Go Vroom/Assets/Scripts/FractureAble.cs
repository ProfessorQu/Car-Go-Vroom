using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureAble : MonoBehaviour
{
    public GameObject[] fractured;
    public float explosionForce = 10f;

    public void Hit(Vector3 point) {
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.enabled = false;
        
        GameObject fractured = SpawnRandomFractured(transform.position);
        Rigidbody[] pieces = fractured.GetComponentsInChildren<Rigidbody>();

        foreach (var piece in pieces) {
            piece.AddExplosionForce(explosionForce, point, 1000f);
        }

        Destroy(gameObject);
    }

    GameObject SpawnRandomFractured(Vector3 pos) {
        int idx = Random.Range(0, fractured.Length);
        return Instantiate(fractured[idx], pos, Quaternion.identity);
    }
}
