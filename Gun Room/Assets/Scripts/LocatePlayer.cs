using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocatePlayer : MonoBehaviour
{
    private Vector3 position, playerPosition;
    private GameObject player;
    private Animator animator;
    private SpriteRenderer sprite, status;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        status = gameObject.transform.Find("Status").GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        position = Camera.main.WorldToScreenPoint(transform.position);
        playerPosition = Camera.main.WorldToScreenPoint(player.transform.position);
        if (playerPosition.y > position.y)
        {
            sprite.sortingOrder = 15;
            status.sortingOrder = 16;
            if (playerPosition.x < (position.x - Screen.width / 6))
            {
                animator.SetInteger("playerPosition", 1);
            }
            else if (playerPosition.x > (position.x + Screen.width / 6))
            {
                animator.SetInteger("playerPosition", 3);
            }
            else
            {
                if (playerPosition.y > (position.y - Screen.height / 6) && playerPosition.y < (position.y + Screen.height / 6))
                {
                    if (playerPosition.x < (position.x - Screen.width / 18))
                    {
                        animator.SetInteger("playerPosition", 1);
                    }
                    else if (playerPosition.x > (position.x + Screen.width / 18))
                    {
                        animator.SetInteger("playerPosition", 3);
                    }
                    else
                    {
                        animator.SetInteger("playerPosition", 2);
                    }
                }
                else
                    animator.SetInteger("playerPosition", 2);
            }
        }
        else
        {
            sprite.sortingOrder = 8;
            status.sortingOrder = 9;
            if (playerPosition.x < (position.x - Screen.width / 6))
            {
                animator.SetInteger("playerPosition", 4);
            }
            else if (playerPosition.x > (position.x + Screen.width / 6))
            {
                animator.SetInteger("playerPosition", 6);
            }
            else
            {
                if (playerPosition.y > (position.y - Screen.height / 6) && playerPosition.y < (position.y + Screen.height / 6))
                {
                    if (playerPosition.x < (position.x - Screen.width / 18))
                    {
                        animator.SetInteger("playerPosition", 4);
                    }
                    else if (playerPosition.x > (position.x + Screen.width / 18))
                    {
                        animator.SetInteger("playerPosition", 6);
                    }
                    else
                    {
                        animator.SetInteger("playerPosition", 5);
                    }
                }
                else
                {
                    animator.SetInteger("playerPosition", 5);
                }
            }
        }
    }
}
