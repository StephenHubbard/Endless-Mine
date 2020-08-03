using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MineBlock : MonoBehaviour
{

    private bool colliderInBlock = false;
    private GameObject currentBlock = null;
    private EquippedInventory equippedInventory;

    public GameObject torch;
    public GameObject ladder;




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
        currentBlock = null;
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

        if (Input.GetMouseButton(0) && !colliderInBlock && equippedInventory.activeSlots[3])
        {
            PlaceLadder();
        }
    }

    private void PlaceLadder()
    {
        int roundedX = Mathf.RoundToInt(transform.position.x);
        int roundedY = Mathf.RoundToInt(transform.position.y);
        Vector2 roundedVector2 = new Vector2(roundedX, roundedY);
        Instantiate(ladder, roundedVector2, Quaternion.identity);
        torchSFX.Play();
    }

    private void PlaceTorch()
    {
        Instantiate(torch, currentBlock.transform.position, Quaternion.identity);
        torchSFX.Play();
    }

    private void HitBlock()
    {
        if (currentBlock != null)
        {
            if (!currentBlock.GetComponent<Pickup>())
            {
                blockIntoPickup();
                dirtSFX.Play();
                colliderInBlock = false;
            }
        }
    }

    // Call from player movement
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
            currentBlock.GetComponent<CircleCollider2D>().radius = 1.2f;
            currentBlock.GetComponent<CircleCollider2D>().isTrigger = true;
            
            GameObject thisBlock = currentBlock;
            StartCoroutine(addPickUpDelay(thisBlock));
        }
        currentBlock = null;
        colliderInBlock = false;
    }

    private IEnumerator addPickUpDelay(GameObject thisBlock)
    {
        yield return new WaitForSeconds(.2f);
        thisBlock.AddComponent<Pickup>();
    }

}
