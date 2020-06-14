using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateGun : MonoBehaviour
{
    Vector2 mousePosition, gunPosition;
    float angle;

    void Update()
    {
        gunPosition = Camera.main.WorldToViewportPoint(transform.position);
        mousePosition = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        angle = Mathf.Atan2(gunPosition.y - mousePosition.y, gunPosition.x - mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 100));
        if (Input.mousePosition.y > Screen.height / 2)
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 9;
        else
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 11;
    }
}
