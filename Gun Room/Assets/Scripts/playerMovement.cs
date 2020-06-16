using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    float horizontal, vertical, movementLimit = 0.7f, trapped = 0;
    Animator playerAnimator;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    void Update()
    {
        GameObject triggeredTrap = null;
        if(GameObject.FindWithTag("Trap") != null)
        {
            foreach (GameObject trap in GameObject.FindGameObjectsWithTag("Trap"))
            {
                if (Vector3.Distance(transform.position, trap.transform.position) < 0.3)
                { 
                    body.velocity = Vector3.zero;
                    playerAnimator.SetBool("moving", false);
                    triggeredTrap = trap;
                    trap.GetComponent<SpriteRenderer>().sortingOrder = 11;
                    trap.GetComponent<Animator>().SetBool("triggered", true);
                    trapped = 500;
                }
            }
        }
        if (trapped > 0)
            trapped--;
        else
        {
            if (triggeredTrap != null)
                Destroy(triggeredTrap);
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            if (horizontal != 0 && vertical != 0)
            {
                horizontal *= movementLimit;
                vertical *= movementLimit;
            }
            if (horizontal != 0 || vertical != 0)
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
}
