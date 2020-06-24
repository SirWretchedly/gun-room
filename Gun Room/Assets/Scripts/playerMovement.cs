using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed = 4;
    public float trapped = 0;

    private float horizontal, vertical, movementLimit = 0.7f;
    private Animator animator, status;
    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        status = gameObject.transform.Find("Status").gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if(GameObject.FindWithTag("Trap") != null)
        {
            foreach (GameObject trap in GameObject.FindGameObjectsWithTag("Trap"))
            {
                if (Vector3.Distance(transform.position, trap.transform.position) < 0.3)
                { 
                    body.velocity = Vector3.zero;
                    animator.SetBool("moving", false);
                    trap.GetComponent<SpriteRenderer>().sortingOrder = 11;
                    status.SetBool("trapped", true);
                    Destroy(trap);
                    trapped = 350;
                }
            }
        }
        if (trapped > 0)
        {
            trapped--;
        } 
        else
        {
            status.SetBool("trapped", false);
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            if (horizontal != 0 && vertical != 0)
            {
                horizontal *= movementLimit;
                vertical *= movementLimit;
            }
            if (horizontal != 0 || vertical != 0)
            {
                animator.SetBool("moving", true);
            }
            else
            {
                animator.SetBool("moving", false);
            }
            body.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
        }
    }
}
