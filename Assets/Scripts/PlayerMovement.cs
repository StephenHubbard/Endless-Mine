using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Rigidbody2D myRigidBody;
    public Animator myAnimator;
    public GameObject equippedItemSprite;
    MineBlock activeItem;
    public float runSpeed = 40f;
    [SerializeField] float miningSpeed = 1f;
    float horizontalMove = 0f;
    bool jump = false;
    bool isFlipped = false;

    


    private void Awake()
    {
        activeItem = FindObjectOfType<MineBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
    }

    private void FixedUpdate()
    {
        Move();
        Swing();
    }

    private void GetInputs()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            myAnimator.SetBool("isJumping", true);
        }
    }

    private void Move()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > .1f;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);

        if (controller.m_Grounded)
        {
            myAnimator.SetBool("isJumping", false);
        }
        else
        {
            myAnimator.SetBool("isJumping", true);
        }

    }

    public void Swing()
    {
        if (Input.GetMouseButton(0))
        {
            myAnimator.SetBool("isSwinging", true);
            myAnimator.speed = miningSpeed;

        }
        else
        {
            myAnimator.SetBool("isSwinging", false);
        }

        if (!Input.GetMouseButton(0))
        {
            equippedItemSprite.SetActive(false);

        }
    }


    // Animator functions
    public void Hit()
    {
        activeItem.CheckActiveItem();
        equippedItemSprite.SetActive(false);
    }

    public void PickaxeActive()
    {
        equippedItemSprite.SetActive(true);
    }
}
