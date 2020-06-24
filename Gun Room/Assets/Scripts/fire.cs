using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public Vector2 mousePosition, bulletPosition;
    public GameObject bullet;

    private GameObject currentBullet;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            currentBullet.GetComponent<bulletMove>().mousePosition = mousePosition;
            gameObject.transform.parent.GetComponent<Animator>().SetBool("firing", true);
        }
        else
        {
            gameObject.transform.parent.GetComponent<Animator>().SetBool("firing", false);
        } 
    }
}
