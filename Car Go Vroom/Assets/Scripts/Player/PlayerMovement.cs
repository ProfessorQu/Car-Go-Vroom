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
        rb.AddForce(steer * steerForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        
        rb.AddForce(0, 0, driveForce * Time.deltaTime);
        
        if (rb.position.y < -1f) {
            Game_Manager.instance.EndGame();
        }
    }

    public void ResetVelocity() {
        rb.velocity = new Vector3(0, 0, 0);
    }
}
