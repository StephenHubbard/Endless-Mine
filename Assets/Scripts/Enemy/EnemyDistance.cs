using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistance : MonoBehaviour
{
    PlayerMovement player;
    Transform childTransform;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
        childTransform = transform.GetChild(0);
    }

    void Start()
    {
        
    }

    void Update()
    {
        setActive();
        followChild();   
    }

    private void followChild()
    {
        // TO DO - fix parent positioning for disabling inside chunks
        //transform.position = childTransform.position;
    }

    private void setActive()
    {
        Transform playerTransform = player.transform;
        float playerDistance = Vector3.Distance(playerTransform.position, transform.position);

        if (playerDistance > 20f)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
