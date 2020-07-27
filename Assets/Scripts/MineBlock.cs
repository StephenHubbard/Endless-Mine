using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MineBlock : MonoBehaviour
{

    private bool colliderInBlock = false;
    private GameObject currentBlock = null;

    // Audio sources
    public AudioSource dirtSFX;

    private void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        currentBlock = other.gameObject;
        colliderInBlock = true;
    }

    private void OnTriggerExit(Collider other)
    {
        colliderInBlock = false;
    }

    private void destroyBlock()
    {
        if (Input.GetMouseButton(0) && colliderInBlock)
        {
            HitBlock();
        }
    }

    private void HitBlock()
    {
        Destroy(currentBlock);
        dirtSFX.Play();
        colliderInBlock = false;
    }

    public void checkIfMineBlockExists()
    {
        destroyBlock();
    }

}
