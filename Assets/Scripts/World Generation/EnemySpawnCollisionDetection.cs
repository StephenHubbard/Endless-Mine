using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnCollisionDetection : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(destroyCollisionDetectionScript());
    }

    // TODO hacky way to solve enemy spawn issue.  
    // Spawns everywhere then destroyed if small trigger collision detects a block which is destroyed 1second later.
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BlockInfo>())
        {
            Destroy(transform.gameObject);
        }
    }

    private IEnumerator destroyCollisionDetectionScript()
    {
        yield return new WaitForSeconds(1f);
        Destroy(GetComponent<EnemySpawnCollisionDetection>());
    }
}
