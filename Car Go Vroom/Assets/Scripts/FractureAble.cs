using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureAble : MonoBehaviour
{
    public GameObject[] fracturedObjects;
    public float explosionForce = 10f;

    public void Hit(Vector3 point) {
        BoxCollider collider = GetComponent<BoxCollider>();
        collider.enabled = false;

        SpawnFractures(point);

        Destroy(gameObject);
    }

    void SpawnFractures(Vector3 point) {
        Vector3 scale = transform.lossyScale;
        Vector3 pos = transform.position;
        int numFractures = (int)(scale.x / 0.5);
        float startPosX = pos.x - (scale.x - 0.5f);

        for (int i = 0; i < numFractures; i++) {
            Vector3 fracPos = new Vector3((float)(startPosX + i), pos.y, pos.z);
            GameObject obj = SpawnRandomFractured(fracPos);

            Rigidbody[] pieces = obj.GetComponentsInChildren<Rigidbody>();
            
            foreach(var piece in pieces) {
                piece.AddExplosionForce(explosionForce, point, 2f);
			}
		}
	}

    GameObject SpawnRandomFractured(Vector3 pos) {
        int idx = Random.Range(0, fracturedObjects.Length);
        return Instantiate(fracturedObjects[idx], pos, Quaternion.identity);
    }
}
