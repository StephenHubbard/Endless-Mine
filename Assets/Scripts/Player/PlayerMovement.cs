using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Rigidbody2D myRigidBody;
    public Animator myAnimator;
    public GameObject equippedItemSprite;
    MineBlock activeItem;
    public float runSpeed = 40f;
    public float climbSpeed = 40f;
    [SerializeField] float miningSpeed = 1f;
    float horizontalMove = 0f;
    bool jump = false;
    bool isFlipped = false;
    CircleCollider2D myFeet;
    float gravityScaleAtStart;

    CursorType currentCursorType;

    [System.Serializable]
    struct CursorMapping
    {
        public CursorType type;
        public Texture2D texture;
        public Vector2 hotspot;
    }

    [SerializeField] CursorMapping[] cursorMappings = null;

    private void Awake()
    {
        activeItem = FindObjectOfType<MineBlock>();
        myFeet = GetComponent<CircleCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;

    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        InteractWithCursor();
    }

    private void FixedUpdate()
    {
        Climb();
        Swing();
        Move();
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

    private void InteractWithCursor()
    {
        if (InteractWithUI()) return;
        InteractWithNothing();
    }

    private bool InteractWithNothing()
    {
        SetCursor(CursorType.Default);
        return true;
    }

    private bool InteractWithUI()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D[] hits = Physics2D.RaycastAll(pos, new Vector2(0, 0), 0.01f);
        foreach (RaycastHit2D hit in hits)
        {
            GameObject target = hit.transform.gameObject;
            if (target == null) continue;

            if (EventSystem.current.IsPointerOverGameObject())
            {
                SetCursor(CursorType.UI);
                return true;
            }

            if (target.CompareTag("Enemy"))
            {
                SetCursor(CursorType.Combat);
                return true;
            }

            if (target.CompareTag("Shopkeeper"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    FindObjectOfType<DialogueTrigger>().TriggerDialogue();
                }
                SetCursor(CursorType.Shop);
                return true;
            }
        }
        return false;
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    private void SetCursor(CursorType type)
    {
        CursorMapping mapping = GetCursorMapping(type);
        Cursor.SetCursor(mapping.texture, mapping.hotspot, CursorMode.Auto);
    }

    private CursorMapping GetCursorMapping(CursorType type)
    {
        foreach (CursorMapping mapping in cursorMappings)
        {
            if (mapping.type == type)
            {
                currentCursorType = mapping.type;
                return mapping;
            }
        }
        return cursorMappings[0];
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
        else if (!controller.m_Grounded)
        {
            myAnimator.SetBool("isJumping", true);
        }
    }

    private void Climb()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myRigidBody.gravityScale = gravityScaleAtStart;
            if (!controller.m_Grounded)
            {
                myAnimator.SetBool("isJumping", true);
            }
            return;
        }

        myAnimator.SetBool("isJumping", true);
        float controlThrow = Input.GetAxisRaw("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
        myRigidBody.velocity = climbVelocity;
        myRigidBody.gravityScale = 0f;
    }

    public void Swing()
    {
        if (Input.GetMouseButton(0) && currentCursorType != CursorType.Shop && currentCursorType != CursorType.UI)
        {
            {
                myAnimator.SetBool("isSwinging", true);
                myAnimator.speed = miningSpeed;
            }

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
