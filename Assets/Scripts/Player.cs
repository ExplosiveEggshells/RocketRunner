using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public Transform playerGFX;

    public float forwardSpeed = 8f;
    public float strafeSpeed = 6f;
    public float spinSpeed = 10;

    private float currentSpinAngle = 0;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 positionDelta = Vector3.zero;

        float horizontalInput = -Input.GetAxisRaw("Horizontal");

        positionDelta.x += strafeSpeed * Time.deltaTime;
        positionDelta.z += horizontalInput * forwardSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + positionDelta);

        currentSpinAngle += spinSpeed * Time.deltaTime;

        playerGFX.Rotate(spinSpeed * Time.deltaTime, 0f, 0f);
    }
}
