using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float movementSpeed = 3;
    public int trapped = 0;

    private GameObject player;
    private Animator animator, status;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
        status = gameObject.transform.Find("Status").gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (GameObject.FindWithTag("Trap") != null)
        {
            foreach (GameObject trap in GameObject.FindGameObjectsWithTag("Trap"))
            {
                if (Vector3.Distance(transform.position, trap.transform.position) < 0.5)
                {
                    animator.SetBool("moving", false);
                    trap.GetComponent<SpriteRenderer>().sortingOrder = 11;
                    status.SetBool("trapped", true);
                    gameObject.GetComponent<TakeDamage>().hp--;
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
            if (Vector3.Distance(transform.position, player.transform.position) > 0.5)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
                animator.SetBool("moving", true);
            }
            else
            {
                animator.SetBool("moving", false);
            }
        }
    }
}
