using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Netherforge.Combat
{
    public class Damage : MonoBehaviour
    {
        Health health;
        [SerializeField] Vector2 knockback = new Vector2(1f, 1f);


        private void Awake()
        {
            health = FindObjectOfType<Health>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                health.TakeDamage(1f, knockback);
            }
        }
    }
}
