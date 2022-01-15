using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 0.2f;

    public float minX = -3f, maxX = 3f;
    public float minZ = -3f, maxZ = 3f;

    public int numObjects = 5;

    private void Start() {
        InvokeRepeating(nameof(Spawn), 0, spawnInterval);
    }

    void Spawn() {
        for (int i = 0; i < numObjects; i++) {
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);

            Vector3 pos = new Vector3(x, transform.position.y, z);

            GameObject obj = Instantiate(obstaclePrefab, pos, Random.rotation);
            obj.transform.parent = transform;
        }
    }
}
