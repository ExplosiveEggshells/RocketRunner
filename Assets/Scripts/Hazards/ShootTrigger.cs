using UnityEngine;

public class ShootTrigger : MonoBehaviour
{
    public Killable killableTarget;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMissiles playerMissiles = other.gameObject.GetComponent<PlayerMissiles>();
        if (playerMissiles != null)
        {
            playerMissiles.FireMissilesAtKillable(killableTarget);
        }
    }
}
