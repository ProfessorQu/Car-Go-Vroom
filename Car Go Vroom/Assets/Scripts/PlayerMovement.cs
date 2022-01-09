using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public float driveForce;
    public float steerForce;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        float steer = Input.GetAxisRaw("Horizontal");
        Vector3 moveVector = new Vector3(steer * steerForce, 0, driveForce);

        rb.AddForce(moveVector * Time.deltaTime);
    }
}
