using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locateCursor : MonoBehaviour
{
    private Vector3 playerPosition, mousePosition;
    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        playerPosition = Camera.main.WorldToScreenPoint(transform.position);
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
                    {
                        playerAnimator.SetInteger("mousePosition", 1);
                    }       
                    else if (mousePosition.x > (playerPosition.x + Screen.width / 18))
                    {
                        playerAnimator.SetInteger("mousePosition", 3);
                    }
                    else
                    {
                        playerAnimator.SetInteger("mousePosition", 2);
                    }  
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
                    {
                        playerAnimator.SetInteger("mousePosition", 4);
                    }
                    else if (mousePosition.x > (playerPosition.x + Screen.width / 18))
                    {
                        playerAnimator.SetInteger("mousePosition", 6);
                    }  
                    else
                    {
                        playerAnimator.SetInteger("mousePosition", 5);
                    }  
                }
                else
                {
                    playerAnimator.SetInteger("mousePosition", 5);
                }   
            }
        }
    }
}
