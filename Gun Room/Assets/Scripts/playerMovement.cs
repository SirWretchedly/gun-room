using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    float horizontal, vertical, movementLimit = 0.7f;
    Animator playerAnimator;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if(horizontal != 0 && vertical != 0)
        {
            horizontal *= movementLimit;
            vertical *= movementLimit;
        }
        if(horizontal != 0 || vertical != 0)
        {
            playerAnimator.SetBool("moving", true);
        }
        else
        {
            playerAnimator.SetBool("moving", false);
        }
        body.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
    }
}
