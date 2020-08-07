using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistance : MonoBehaviour
{
    PlayerMovement player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        setActive();
    }

    private void setActive()
    {
        Transform playerTransform = player.transform;
        float playerDistance = Vector3.Distance(playerTransform.position, transform.position);

        if (playerDistance > 20f)
        {
            GetComponent<EnemyMovement>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        else
        {
            GetComponent<EnemyMovement>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
