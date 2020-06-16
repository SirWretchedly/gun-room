using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item1 : MonoBehaviour
{
    public GameObject currentItem;
    GameObject player;
    string activeItem;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        activeItem = gameObject.GetComponent<item>().activeItem;
        if (Input.GetKeyDown("1") && activeItem != null)
        {
            currentItem.SetActive(false);
            if (activeItem == "revolver")
            {
                foreach (Transform items in player.transform)
                {
                    if (items.name == "Revolver" || items.name == "Revolver(Clone)")
                    {
                        items.gameObject.SetActive(true);
                        currentItem = items.gameObject;
                        GameObject.Find("Item3").GetComponent<item3>().currentItem = items.gameObject;
                        GameObject.Find("Item2").GetComponent<item2>().currentItem = items.gameObject;
                        break;
                    }
                }
            }
            if (activeItem == "bearTrap")
            {
                foreach (Transform items in player.transform)
                {
                    if (items.name == "BearTrap" || items.name == "BearTrap(Clone)")
                    {
                        items.gameObject.SetActive(true);
                        currentItem = items.gameObject;
                        GameObject.Find("Item3").GetComponent<item3>().currentItem = items.gameObject;
                        GameObject.Find("Item2").GetComponent<item2>().currentItem = items.gameObject;
                        break;
                    }
                }
            }
        }
    }
}
