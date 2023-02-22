using System;
using UnityEngine;

public class Killable : MonoBehaviour
{
    public Action<int> hitPointsChanged;
    public int hitPoints = 5;

    private void Start()
    {
        hitPointsChanged?.Invoke(hitPoints);
    }

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        hitPointsChanged?.Invoke(hitPoints);

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
