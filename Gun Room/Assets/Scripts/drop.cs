using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drop : MonoBehaviour
{
    public GameObject groundedItem;

    void Update()
    {
        if(Input.GetKeyDown("g"))
        {
            Destroy(gameObject);
            Instantiate(groundedItem, transform.position, Quaternion.identity);
        }
    }
}
