using Netherforge.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D rb;

    public bool isGrounded = false;

    PlayerMovement player;

    [SerializeField] Vector2 knockback = new Vector2(1f, 1f);
    Health health;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();

    }

    void Start()
    {
        StartCoroutine(changeDirection());
        StartCoroutine(Jump());
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(changeDirection());
        StartCoroutine(Jump());
    }

    void Update()
    {
        checkDirection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(1f, knockback);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private IEnumerator Jump()
    {
        int randomNum = Random.Range(2, 6);
        yield return new WaitForSeconds(randomNum);

        // check if active in scene warning prevention
        if (rb.bodyType == RigidbodyType2D.Dynamic)
        {
            if (isFacingRight())
            {
                Vector2 jump = new Vector2(1.5f, 5f);
                rb.velocity = jump;
            }
            else if (!isFacingRight())
            {
                Vector2 jump = new Vector2(-1.5f, 5f);
                rb.velocity = jump;
            }
            StartCoroutine(Jump());
        }
    }

    private IEnumerator changeDirection()
    {
        int randomNum = Random.Range(1, 6);
        yield return new WaitForSeconds(randomNum);
        Vector2 newDirection = new Vector2(-transform.localScale.x, 1);
        transform.localScale = newDirection;
        StartCoroutine(changeDirection());
    }

    private void checkDirection()
    {
        if (rb.bodyType == RigidbodyType2D.Dynamic)
        {
            if (isFacingRight() && isGrounded)
            {
                rb.velocity = new Vector2(moveSpeed, 0f);
            }
            else if (!isFacingRight() && isGrounded)
            {
                rb.velocity = new Vector2(-moveSpeed, 0f);
            }
        }
    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }

    
}
