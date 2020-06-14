using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locateCursor : MonoBehaviour
{
    public Vector3 playerPosition, mousePosition;
    GameObject player;
    Animator playerAnimator, gunAnimator;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        gunAnimator = GameObject.FindWithTag("Gun").GetComponent<Animator>();
    }
    void Update()
    {
        playerPosition = player.transform.position;
        playerPosition = Camera.main.WorldToScreenPoint(playerPosition);
        mousePosition = Input.mousePosition;
        if (mousePosition.y > (playerPosition.y + Screen.height / 6))
        {
            if(mousePosition.x < (playerPosition.x- Screen.width / 6))
            {
                playerAnimator.SetInteger("mousePosition", 1);
                gunAnimator.SetInteger("mousePosition", 1);
            }
            else if(mousePosition.x > (playerPosition.x + Screen.width / 6))
            {
                playerAnimator.SetInteger("mousePosition", 3);
                gunAnimator.SetInteger("mousePosition", 3);
            }
            else
            {
                playerAnimator.SetInteger("mousePosition", 2);
                if(mousePosition.x < Screen.width / 2)
                {
                    gunAnimator.SetInteger("mousePosition", 2);
                }
                else
                {
                    gunAnimator.SetInteger("mousePosition", 7);
                }
            }
        }
        else if (mousePosition.y < (playerPosition.y - Screen.height / 6))
        {
            if (mousePosition.x < (playerPosition.x - Screen.width / 6))
            {
                playerAnimator.SetInteger("mousePosition", 4);
                gunAnimator.SetInteger("mousePosition", 4);
            }
            else if (mousePosition.x > (playerPosition.x + Screen.width / 6))
            {
                playerAnimator.SetInteger("mousePosition", 6);
                gunAnimator.SetInteger("mousePosition", 6);
            }
            else
            {
                playerAnimator.SetInteger("mousePosition", 5);
                if (mousePosition.x < Screen.width / 2)
                {
                    gunAnimator.SetInteger("mousePosition", 5);
                }
                else
                {
                    gunAnimator.SetInteger("mousePosition", 8);
                }
            }
        }
        else
        {
            if (mousePosition.x < (playerPosition.x - Screen.width / 6))
            {
                playerAnimator.SetInteger("mousePosition", 4);
                gunAnimator.SetInteger("mousePosition", 8);
            }
            else if (mousePosition.x > (playerPosition.x + Screen.width / 6))
            {
                playerAnimator.SetInteger("mousePosition", 6);
                gunAnimator.SetInteger("mousePosition", 9);
            }
            else
            {
                if (mousePosition.y < Screen.height / 2)
                    playerAnimator.SetInteger("mousePosition", 5);
                else
                    playerAnimator.SetInteger("mousePosition", 2);
                if (mousePosition.x < Screen.width / 2)
                {
                    gunAnimator.SetInteger("mousePosition", 2);
                }
                else
                {
                    gunAnimator.SetInteger("mousePosition", 7);
                }
            }
        }
    }
}
