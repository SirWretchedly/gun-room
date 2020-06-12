using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locateCursor : MonoBehaviour
{
    public Vector3 playerPosition;
    GameObject player;
    Animator playerAnimator;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
    }
    void Update()
    {
        playerPosition = player.transform.position;
        playerPosition = Camera.main.WorldToScreenPoint(playerPosition);
        if (Input.mousePosition.y > playerPosition.y)
        {
            if(Input.mousePosition.x < (playerPosition.x- Screen.width / 9))
            {
                playerAnimator.SetInteger("mousePosition", 1);
            }
            else if(Input.mousePosition.x > (playerPosition.x + Screen.width / 9))
            {
                playerAnimator.SetInteger("mousePosition", 3);
            }
            else
            {
                playerAnimator.SetInteger("mousePosition", 2);
            }
        }
        else
        {
            if (Input.mousePosition.x < (playerPosition.x - Screen.width / 9))
            {
                playerAnimator.SetInteger("mousePosition", 4);
            }
            else if (Input.mousePosition.x > (playerPosition.x + Screen.width / 9))
            {
                playerAnimator.SetInteger("mousePosition", 6);
            }
            else
            {
                playerAnimator.SetInteger("mousePosition", 5);
            }
        }
    }
}
