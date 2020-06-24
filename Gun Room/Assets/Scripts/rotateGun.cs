using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateGun : MonoBehaviour
{
    private Vector3 mousePosition, gunPosition, playerScreen;
    private SpriteRenderer gunSprite;
    private GameObject player;
    private float angle;
    private bool ok = true;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        gunSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        gunPosition = Camera.main.WorldToViewportPoint(transform.position);
        mousePosition = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        angle = Mathf.Atan2(gunPosition.y - mousePosition.y, gunPosition.x - mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 100));
        playerScreen = Camera.main.WorldToScreenPoint(player.transform.position);
        if (Input.mousePosition.y > playerScreen.y)
        {
            gunSprite.sortingOrder = 9;
        }
        else
        {
            gunSprite.sortingOrder = 13;
        }   
        if (Input.mousePosition.x < playerScreen.x && ok)
        {
            gunSprite.flipX = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            ok = false;
        }
        else if (Input.mousePosition.x > playerScreen.x && !ok)
        {
            gunSprite.flipX = false;
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            ok = true;
        }
    }
}
