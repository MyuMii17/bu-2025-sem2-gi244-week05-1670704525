using System;
using UnityEngine;
public class HealthV1 : MonoBehaviour
{
    public float health = 25f;
    public int enemyDead;
    public static Action OnEnemyDead;
    public void TakeDamage(int damage)
    {
        health -=damage;
        if (health <= 0)
        {   
            Die();
        }
    }
    void Die()
    {
        OnEnemyDead?.Invoke();
        Destroy(gameObject);
    }
}
