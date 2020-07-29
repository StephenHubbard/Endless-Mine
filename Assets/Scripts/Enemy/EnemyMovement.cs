using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D rb;

    public bool isGrounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine(changeDirection());
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
        if (isFacingRight() && isGrounded)
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
        else if (!isFacingRight() && isGrounded)
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }
}
