using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showItems : MonoBehaviour
{
    public Sprite[] image;
    public bool[] itemInBar = { false, false };

    private string[] itemID = { "Revolver", "BearTrap" };
    private GameObject player;
    private int n = 2;
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        foreach(Transform item in player.transform)
        {
            
            for (int i = 0; i < n; i++)
            {
                if ((item.name == itemID[i] || item.name == itemID[i] + "(Clone)") && itemInBar[i] == false)
                {
                    foreach (Transform slot in transform)
                    {
                        ItemSlot itemSlot = slot.GetComponent<ItemSlot>();
                        if (itemSlot.currentItem == null)
                        {
                            itemSlot.currentItem = item.gameObject;
                            slot.GetComponent<Image>().sprite = image[i];
                            itemInBar[i] = true;
                            break;
                        }
                    }
                }
            }
        }
    }
}
