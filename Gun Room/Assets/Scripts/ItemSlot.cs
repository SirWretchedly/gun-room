using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public string key;
    public GameObject currentItem = null;

    static GameObject activeItem = null;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if(Input.GetKeyDown(key))
        {
            foreach (Transform item in player.transform)
            {
                if (activeItem != null)
                {
                    if (compareNames(item.name, activeItem.name) == true)
                    {
                        item.gameObject.SetActive(false);
                        break;
                    }
                }
            }
            if (currentItem == null)
            {
                activeItem = null;
            }
            else
            {  
                foreach (Transform item in player.transform)
                {
                    if (compareNames(item.name, currentItem.name) == true)
                    {
                        item.gameObject.SetActive(true);
                        activeItem = item.gameObject;
                        break;
                    }
                }
            }
        }
    }

    private bool compareNames(string a, string b)
    {
        string c = "(Clone)";
        if(a == b || a + c == b || a == b + c)
        {
            return true;
        }
        return false;
    }
}
