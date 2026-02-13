using UnityEngine;

public class HealthV2 : MonoBehaviour
{
    public float maxHp = 100f;
    private int accumDamage = 0;
    public void TakeDamage(int damage)
    {
        accumDamage += damage;
        if(accumDamage >= maxHp)
        {
            Destroy(gameObject);
        }
    }
}
