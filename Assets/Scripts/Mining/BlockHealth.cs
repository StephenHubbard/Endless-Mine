using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHealth : MonoBehaviour
{
    [SerializeField] private int blockHealth;
    [SerializeField] private int blockPower;

    MineBlock mineBlock;

    [SerializeField] AudioClip mineDirtSFX;
    [SerializeField] AudioClip metalClankSFX;



    private void Awake()
    {
        blockHealth = GetComponent<BlockInfo>().block.blockHealth;
        blockPower = GetComponent<BlockInfo>().block.blockPower;
        mineBlock = FindObjectOfType<MineBlock>();
    }

    public void takeDamage(int pickaxePower)
    {
        if (pickaxePower >= blockPower)
        {
            blockHealth -= pickaxePower;
            if (blockHealth <= 0)
            {
                mineBlock.blockIntoPickup();
                AudioSource.PlayClipAtPoint(mineDirtSFX, Camera.main.transform.position, .4f);
            }
        }
        else
        {
            AudioSource.PlayClipAtPoint(metalClankSFX, Camera.main.transform.position, .3f);
        }
    }

}
