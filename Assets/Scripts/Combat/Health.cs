using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Netherforge.Combat
{
    public class Health : MonoBehaviour
    {
        public float currentHealth = 0;
        public Rigidbody2D rb;
        public Animator animator;
        PlayerMovement player;
        private float dirNum;

        EnemyMovement enemy;

        private void Awake()
        {
            player = FindObjectOfType<PlayerMovement>();
        }


        public void TakeDamage(float damage, Vector2 knockback)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                enemy = GetComponent<EnemyMovement>();
                enemy.isGrounded = false;
            }

            Vector3 heading = player.transform.position - transform.position;
            dirNum = AngleDir(transform.forward, heading, transform.up);
            if (dirNum < 0)
            {
                rb.velocity = knockback;
            }
            else
            {
                Vector2 negativeKnockback = new Vector2(-knockback.x, knockback.y);
                rb.velocity = negativeKnockback;
            }

            currentHealth -= damage;
            animator.SetTrigger("takeDamage");
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
        {
            Vector3 perp = Vector3.Cross(fwd, targetDir);
            float dir = Vector3.Dot(perp, up);

            if (dir > 0f)
            {
                return 1f;
            }
            else if (dir < 0f)
            {
                return -1f;
            }
            else
            {
                return 0f;
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
