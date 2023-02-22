using UnityEngine;

public class Missile : MonoBehaviour
{
    public float spinSpeed = 20f;

    private int attackStrength = 1;
    private float currentSpinAngle = 0f;


    private void Awake()
    {
        currentSpinAngle += Random.Range(0f, 360f);
    }

    private void Update()
    {

        currentSpinAngle += spinSpeed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        transform.Rotate(currentSpinAngle, 0f, 0f);
    }


}
