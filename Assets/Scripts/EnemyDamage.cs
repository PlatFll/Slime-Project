using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.GetComponent<Health>() != null && gameObject.GetComponent<Health>().currentHealth > 0)
            {
                if(collision.tag == "Player")
                {
                    collision.GetComponent<Health>().TakeDamage(damage);
                }
            }
        else if (gameObject.GetComponent<Health>() == null)
        {
                if(collision.tag == "Player")
                {
                    collision.GetComponent<Health>().TakeDamage(damage);
                }
        }
    }
}
