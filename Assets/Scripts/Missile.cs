using UnityEngine;

public class Missile : MonoBehaviour
{
    public int attackStrength = 1;

    public float spinSpeed = 20f;

    public float flySpeed = 30f;
    public float detonateDistance = 0.5f;

    private float currentSpinAngle = 0f;

    private Killable fireTarget;
    private bool firing = false;

    public void FireAtTarget(Killable target)
    {
        transform.SetParent(null);
        firing = true;
        fireTarget = target;
    }

    private void Awake()
    {
        currentSpinAngle += Random.Range(0f, 360f);
    }

    private void Update()
    {
        if (!firing)
        {
            currentSpinAngle += spinSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
            transform.Rotate(0f, 0f, currentSpinAngle);
        }
        else
        {
            currentSpinAngle += spinSpeed * 3 * Time.deltaTime;
            Vector3 targetDirection = fireTarget.transform.position - transform.position;
            targetDirection.Normalize();

            transform.rotation = Quaternion.LookRotation(targetDirection, Vector3.up);

            transform.position += flySpeed * Time.deltaTime * targetDirection;

            if (Vector3.Distance(transform.position, fireTarget.transform.position) <= detonateDistance)
            {
                Detonate();
            }
        }
    }

    private void Detonate()
    {
        fireTarget.TakeDamage(attackStrength);
        Destroy(gameObject);
    }
}
