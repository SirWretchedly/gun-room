using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float movementSpeed = 3;

    private GameObject player;
    private Animator animator;
    private int trapped;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (GameObject.FindWithTag("Trap") != null)
        {
            foreach (GameObject trap in GameObject.FindGameObjectsWithTag("Trap"))
            {
                if (Vector3.Distance(transform.position, trap.transform.position) < 0.3)
                {
                    animator.SetBool("moving", false);
                    trap.GetComponent<SpriteRenderer>().sortingOrder = 11;
                    gameObject.transform.Find("Status").gameObject.GetComponent<Animator>().SetBool("trapped", true);
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
            if (Vector3.Distance(transform.position, player.transform.position) > 1)
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
