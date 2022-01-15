using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Vector3 rotation = new Vector3(0.1f, 0.2f, 0.01f);

    private void FixedUpdate() {
        transform.Rotate(rotation);
    }
}
