using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class set : MonoBehaviour
{
    public GameObject trap, blankItem;
    GameObject inventory;
    public Sprite blank;

    private void Start()
    {
        inventory = GameObject.Find("Bar");
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z += 10;
        if (Input.GetMouseButtonDown(0) && Vector3.Distance(mousePosition, gameObject.transform.position + new Vector3(-0.4f, +0.2f, 0)) < 1.7)
        {
            Instantiate(trap, mousePosition + new Vector3(0.4f, -0.2f, 0), Quaternion.identity);
            Destroy(gameObject);
            foreach(Transform slot in inventory.transform)
            {
                if(slot.gameObject.GetComponent<item>().activeItem == "bearTrap")
                {
                    slot.gameObject.GetComponent<item>().activeItem = "blank";
                    slot.gameObject.GetComponent<Image>().sprite = blank;
                    break;
                }
            }
            GameObject.Find("Item3").GetComponent<item3>().currentItem = blankItem;
            GameObject.Find("Item2").GetComponent<item2>().currentItem = blankItem;
            GameObject.Find("Item1").GetComponent<item1>().currentItem = blankItem;
            GameObject.Find("Bar").GetComponent<showItems>().itemInBar[1] = false;
        }  
    }
}
