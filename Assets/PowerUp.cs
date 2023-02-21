using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int playerLayer;
    public float flyDirectionChangeSpeed = 1f;
    public float flySpeedAcceleration = 8f;

    public float pickUpDistance = 0.5f;

    private bool flying = false;

    private Transform flyTarget;
    private Vector3 flyDirection;
    private float flySpeed;

    private void Update()
    {
        if (flying && flyTarget != null)
        {
            UpdateFlight();
        }
    }

    private void CollectPowerUp()
    {
        if (Vector3.Distance(transform.position, flyTarget.position) <= pickUpDistance)
        {
            Debug.Log("Picked up " + gameObject.name);
            Destroy(gameObject);
        }
    }

    private void UpdateFlight()
    {
        flySpeed += flySpeedAcceleration * Time.deltaTime;
        transform.position += flySpeed * Time.deltaTime * flyDirection;

        transform.position = new Vector3(
            transform.position.x,
            Mathf.Max(transform.position.y, 0f),
            transform.position.z
        );

        Vector3 correctDirection = Vector3.Normalize(flyTarget.position - transform.position);

        flyDirection = Vector3.MoveTowards(flyDirection, correctDirection, flyDirectionChangeSpeed * Time.deltaTime);
        CollectPowerUp();
    }

    private void BeginFlying(Transform target)
    {
        flyTarget = target;
        flySpeed = 0f;
        flying = true;

        flyDirection = Vector3.Normalize(target.position - transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello!");
        if (!flying && other.gameObject.layer == playerLayer)
        {
            Debug.Log("Goodbye!!");
            BeginFlying(other.transform);
            return;
        }
    }
}
