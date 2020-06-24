using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class set : MonoBehaviour
{
    public GameObject trap;
    public Sprite blank;

    private GameObject inventory;
    Vector3 mousePosition;

    private void Start()
    {
        inventory = GameObject.Find("Bar");
    }

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z += 10;
        if (Input.GetMouseButtonDown(0) && Vector3.Distance(mousePosition, gameObject.transform.position) < 1.7)
        {
            Instantiate(trap, mousePosition, Quaternion.identity);
            Destroy(gameObject);
            foreach(Transform slot in inventory.transform)
            {
                ItemSlot itemSlot = slot.gameObject.GetComponent<ItemSlot>();
                if (itemSlot.currentItem == gameObject)
                {
                    slot.gameObject.GetComponent<ItemSlot>().currentItem = null;
                    slot.gameObject.GetComponent<Image>().sprite = blank;
                    break;
                }
            }
            GameObject.Find("Bar").GetComponent<showItems>().itemInBar[1] = false;
        }  
    }
}
