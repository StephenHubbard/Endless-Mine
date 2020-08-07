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

        Vector2 startingPlayerPosition;

        bool playerTakeDamageCD = false;

        [SerializeField] AudioClip hurtSFX;
        [SerializeField] AudioClip jellyAttackSFX;


        private void Awake()
        {
            player = FindObjectOfType<PlayerMovement>();
            startingPlayerPosition = player.transform.position;
        }


        public void TakeDamage(float damage, Vector2 knockback)
        {
            if (playerTakeDamageCD == false)
            {
                if (gameObject.CompareTag("Enemy"))
                {
                    AudioSource.PlayClipAtPoint(hurtSFX, Camera.main.transform.position, .2f);
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

                // take damage cd to prevent multiple hits in quick succession
                if (gameObject.CompareTag("Player"))
                {
                    AudioSource.PlayClipAtPoint(jellyAttackSFX, Camera.main.transform.position, .5f);
                    playerTakeDamageCD = true;
                    StartCoroutine(takeDamageCD());
                }
            }
        }

        private IEnumerator takeDamageCD()
        {
            yield return new WaitForSeconds(1f);
            playerTakeDamageCD = false;
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
            if (gameObject.CompareTag("Player"))
            {
                player.transform.position = startingPlayerPosition;
                currentHealth = 3;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
