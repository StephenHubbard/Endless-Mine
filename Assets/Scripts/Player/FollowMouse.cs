using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject extensionSprite;
    public CharacterController2D controller;


    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<PlayerMovement>().controller;
    }

    // Update is called once per frame
    void Update()
    {
        FaceMouse();
    }

    private void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (controller.m_FacingRight)
        {
            Vector2 direction = new Vector2(mousePosition.x - transform.position.x , mousePosition.y - transform.position.y);
            transform.right = direction;
        }
        else
        {
            Vector2 direction = new Vector2(transform.position.x - mousePosition.x, transform.position.y - mousePosition.y);
            transform.right = direction;

        }
    }
}
