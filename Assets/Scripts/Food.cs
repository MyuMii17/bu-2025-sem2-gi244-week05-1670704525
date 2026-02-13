using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int attackPoint = 5;
    [SerializeField]private GameObject hitVfxPrefeb;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit" + other.gameObject.name);
        // HealthV1 attackA = other.GetComponent<HealthV1>();
        // if(other != null)
        // {
        //     attackA.TakeDamage(attackPoint);
        // }
        if(other.gameObject.TryGetComponent<HealthV1>(out HealthV1 health))
        {
            health.TakeDamage(attackPoint);
        }
        var hitVfx = Instantiate(hitVfxPrefeb,transform.position,Quaternion.identity);
        //hitVfx.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
        Destroy(hitVfx,0.5f);
        Destroy(gameObject);
    }
}
