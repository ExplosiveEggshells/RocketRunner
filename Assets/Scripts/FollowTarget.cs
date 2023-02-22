using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 offset;

    [SerializeField] private bool useAwakeOffset = true;
    [SerializeField] private bool lookAtTarget = true;

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
            
            if (lookAtTarget)
            {
                transform.LookAt(followTarget, Vector3.up);
            }
        }
    }
}
