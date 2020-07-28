using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MineBlock : MonoBehaviour
{

    private bool colliderInBlock = false;
    private GameObject currentBlock = null;
    private EquippedInventory equippedInventory;

    public GameObject torch;



    // Audio sources
    public AudioSource dirtSFX;
    public AudioSource torchSFX;

    private void Awake()
    {
        equippedInventory = FindObjectOfType<EquippedInventory>();

    }

    private void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        currentBlock = other.gameObject;
        colliderInBlock = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        colliderInBlock = false;
    }

    private void detectItem()
    {
        if (Input.GetMouseButton(0) && colliderInBlock && equippedInventory.activeSlots[0])
        {
            HitBlock();
        }

        if (Input.GetMouseButton(0) && colliderInBlock && equippedInventory.activeSlots[1])
        {
            PlaceTorch();

        }
    }

    private void PlaceTorch()
    {
        Instantiate(torch, transform.position, Quaternion.identity);
        torchSFX.Play();
    }

    private void HitBlock()
    {
        Destroy(currentBlock);
        dirtSFX.Play();
        colliderInBlock = false;
    }

    public void CheckActiveItem()
    {
        detectItem();
    }

}
