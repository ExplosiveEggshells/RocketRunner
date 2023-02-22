using UnityEngine;

[RequireComponent(typeof(Killable))]
public class KillWall : MonoBehaviour
{
    private Killable killableScript;

    private void Awake()
    {
        killableScript = GetComponent<Killable>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log(collision.gameObject);
            player.Die();
        }
        return;
    }
}
