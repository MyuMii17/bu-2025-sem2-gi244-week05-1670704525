using UnityEngine;

public class HealthV1 : MonoBehaviour
{
    public float health = 25f;
    public void TakeDamage(int damage)
    {
        health -=damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
