using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public Transform playerGFX;

    public float forwardSpeed = 8f;
    public float strafeSpeed = 6f;
    public float spinSpeed = 10;

    
    private int points;
    private float currentSpinAngle = 0;

    private Rigidbody rb;

    public void AddPoints(int count)
    {
        Points += count;
    }

    public void Kill()
    {
        // Kill player
    }

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Points = 0;
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

    public int Points { get => points; private set => Mathf.Max(value, 0); }

}
