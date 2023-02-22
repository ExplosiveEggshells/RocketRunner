using System;
using UnityEngine;

public class Killable : MonoBehaviour
{
    public Action<int> hitPointsChanged;
    public int hitPoints = 5;

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        hitPointsChanged?.Invoke(damage);

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
