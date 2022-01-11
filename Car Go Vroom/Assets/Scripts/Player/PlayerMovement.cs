using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Transform tf;

    public float driveForce;
    public float steerForce;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    private void FixedUpdate() {
        float steer = Input.GetAxisRaw("Horizontal");
        rb.AddForce(0, 0, driveForce * Time.deltaTime);

        rb.AddForce(steer * steerForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (rb.position.y < -1f) {
            Game_Manager.instance.EndGame();
        }
    }
}
