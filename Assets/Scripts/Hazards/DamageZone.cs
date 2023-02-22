using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DamageZone : MonoBehaviour
{
    public float ticksPerSecond = 1f;
    public int damagePerTick = 1;

    private PlayerMissiles targetPlayerMissiles;

    private bool damagingPlayer;
    private float tickInterval;
    private float timeSinceLastTick;

    private void Awake()
    {
        tickInterval = 1 / ticksPerSecond;
        damagingPlayer = false;
        timeSinceLastTick = tickInterval;
    }

    private void Update()
    {
        if (damagingPlayer)
        {
            timeSinceLastTick += Time.deltaTime;
            if (timeSinceLastTick >= tickInterval)
            {
                DamagePlayer();
                timeSinceLastTick = 0f;
            }
        }
    }

    private void DamagePlayer()
    {
        targetPlayerMissiles.RemoveMissilePoints(damagePerTick);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerMissiles playerMissiles = other.gameObject.GetComponent<PlayerMissiles>();
        if (playerMissiles != null)
        {
            damagingPlayer = true;
            timeSinceLastTick = (3 * tickInterval) / 4;   // Very small grace period
            targetPlayerMissiles = playerMissiles;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMissiles playerMissiles = other.gameObject.GetComponent<PlayerMissiles>();
        if (playerMissiles != null)
        {
            damagingPlayer = false;
            targetPlayerMissiles = null;
        }
    }
}
