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
    }
    void Update()
    {
        playerPosition = player.transform.position;
        playerPosition = Camera.main.WorldToScreenPoint(playerPosition);
        mousePosition = Input.mousePosition;
        if (mousePosition.y > playerPosition.y)
        {
            if(mousePosition.x < (playerPosition.x- Screen.width / 6))
            {
                playerAnimator.SetInteger("mousePosition", 1);
            }
            else if(mousePosition.x > (playerPosition.x + Screen.width / 6))
            {
                playerAnimator.SetInteger("mousePosition", 3);
            }
            else
            {
                if(mousePosition.y > (playerPosition.y - Screen.height / 6) && mousePosition.y < (playerPosition.y + Screen.height / 6))
                {
                        if (mousePosition.x < (playerPosition.x - Screen.width / 18))
                            playerAnimator.SetInteger("mousePosition", 1);
                        else if (mousePosition.x > (playerPosition.x + Screen.width / 18))
                            playerAnimator.SetInteger("mousePosition", 3);
                        else
                            playerAnimator.SetInteger("mousePosition", 2);
                }
                else
                    playerAnimator.SetInteger("mousePosition", 2);
            }
        }
        else
        {
            if (mousePosition.x < (playerPosition.x - Screen.width / 6))
            {
                playerAnimator.SetInteger("mousePosition", 4);
            }
            else if (mousePosition.x > (playerPosition.x + Screen.width / 6))
            {
                playerAnimator.SetInteger("mousePosition", 6);
            }
            else
            {
                if (mousePosition.y > (playerPosition.y - Screen.height / 6) && mousePosition.y < (playerPosition.y + Screen.height / 6))
                {
                    if (mousePosition.x < (playerPosition.x - Screen.width / 18))
                        playerAnimator.SetInteger("mousePosition", 4);
                    else if (mousePosition.x > (playerPosition.x + Screen.width / 18))
                        playerAnimator.SetInteger("mousePosition", 6);
                    else
                        playerAnimator.SetInteger("mousePosition", 5);
                }
                else
                    playerAnimator.SetInteger("mousePosition", 5);
            }
        }
    }
}
