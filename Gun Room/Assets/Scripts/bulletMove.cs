using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    public Vector3 mousePosition;
    public float movementSpeed;

    private void Start()
    {
        mousePosition = transform.position + (mousePosition - transform.position).normalized * 1000;
    }

    void Update()
    {
        if (gameObject.tag == "Bullet")
        {
            transform.position = Vector3.MoveTowards(transform.position, mousePosition, movementSpeed * Time.deltaTime);
        }  
    }
}
