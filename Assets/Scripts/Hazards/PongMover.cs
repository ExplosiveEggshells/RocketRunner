using UnityEngine;

public class PongMover : MonoBehaviour
{
    public float zMinimum = -25f;
    public float zMaximum = 25f;

    public float movementSpeed = 10f;
    public bool movingToMaximum = true;

    private Vector3 maximumPosition;
    private Vector3 minimumPosition;

    private void Awake()
    {
        maximumPosition = new Vector3(transform.position.x, transform.position.y, zMaximum);
        minimumPosition = new Vector3(transform.position.x, transform.position.y, zMinimum);
    }

    private void Update()
    {
        if (movingToMaximum)
        {
            transform.position = Vector3.MoveTowards(transform.position, maximumPosition, movementSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, maximumPosition) <= 0.5f)
            {
                movingToMaximum = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, minimumPosition, movementSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, minimumPosition) <= 0.5f)
            {
                movingToMaximum = true;
            }
        }
    }


}
