using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 offset;

    [SerializeField] private bool useAwakeOffset = true;

    private void Awake()
    {
        if (useAwakeOffset && followTarget != null)
        {
            offset = transform.position - followTarget.position;
        }
    }

    private void LateUpdate()
    {
        if (followTarget != null)
        {
            transform.position = followTarget.position + offset;
            transform.LookAt(followTarget, Vector3.up);
        }
    }
}
