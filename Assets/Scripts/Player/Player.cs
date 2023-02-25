using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public Transform playerGFX;
    public Transform PlayerGFXSpinner;

    public float forwardSpeed = 8f;
    public float strafeSpeed = 6f;
    public float strafeAcceleration = 24f;

    public float spinSpeed = 10;
    public float strafeSpinAngle = 30f;

    private float currentSpinAngle = 0;

    private float strafeVelocity = 0;

    private Rigidbody rb;

    public void Die()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 positionDelta = Vector3.zero;

        float horizontalInput = -Input.GetAxisRaw("Horizontal");

        strafeVelocity = Mathf.MoveTowards(strafeVelocity, horizontalInput * strafeSpeed, strafeAcceleration * Time.deltaTime);

        positionDelta.x += forwardSpeed * Time.deltaTime;
        positionDelta.z += strafeVelocity *  Time.deltaTime;

        rb.MovePosition(transform.position + positionDelta);

        float accelerationAngle = GetAccelerationRotation();

        Vector3 eulerAngles = playerGFX.eulerAngles;
        eulerAngles.y = accelerationAngle + 180f;
        eulerAngles.x = accelerationAngle;

        playerGFX.localRotation = Quaternion.Euler(eulerAngles);
        //PlayerGFXSpinner.Rotate(spinSpeed * Time.deltaTime, 0f, 0f);
    }

    private float GetAccelerationRotation()
    {
        float strafeSpeedPerc = -strafeVelocity / strafeSpeed;
        return strafeSpinAngle * strafeSpeedPerc;
    }
}
