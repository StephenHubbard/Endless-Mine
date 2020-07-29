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
        if (other.gameObject.tag == "Block")
        {
            currentBlock = other.gameObject;
            colliderInBlock = true;
        }
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
        if (!currentBlock.GetComponent<Pickup>())
        {
            blockIntoPickup();
            dirtSFX.Play();
            colliderInBlock = false;
        }
    }

    public void CheckActiveItem()
    {
        detectItem();
    }

    private void blockIntoPickup()
    {
        currentBlock.transform.localScale = new Vector3(.5f, .5f, .5f);
        if (!currentBlock.GetComponent<Rigidbody2D>())
        {
            currentBlock.AddComponent<Rigidbody2D>();
            currentBlock.AddComponent<CircleCollider2D>();
            currentBlock.GetComponent<CircleCollider2D>().radius = 1.5f;
            currentBlock.GetComponent<CircleCollider2D>().isTrigger = true;
            GameObject thisBlock = currentBlock;
            currentBlock = null;
            StartCoroutine(addPickUpDelay(thisBlock));
        }
    }

    private IEnumerator addPickUpDelay(GameObject thisBlock)
    {
        yield return new WaitForSeconds(.2f);
        thisBlock.AddComponent<Pickup>();
    }

}
