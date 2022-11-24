using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Boss_mechanics bossMech = collision.gameObject.GetComponent<Boss_mechanics>();
        if (bossMech != null)
            bossMech.TakeDamage(1);
    }
}
