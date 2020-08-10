using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchInfo : MonoBehaviour
{
    public Torch torch;

    GameObject attachedBlock;
    bool attached = false;

    public void getAttachedBlock(GameObject thisBlock)
    {
        attachedBlock = thisBlock;
        attached = true;
    }

    private void Update()
    {
        if (attachedBlock == null && attached == true && !GetComponent<Rigidbody2D>())
        {
            transform.gameObject.AddComponent<Rigidbody2D>();
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            var Yvelocity = rb.velocity.y;
            Yvelocity = -1;
            gameObject.AddComponent<Pickup>();
        }
    }
}
