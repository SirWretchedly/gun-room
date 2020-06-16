using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showItems : MonoBehaviour
{
    public Sprite blank, revolver, bearTrap;
    GameObject player;
    public bool[] itemInBar = { false, false };

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        foreach(Transform item in player.transform)
        {
            if ((item.name == "Revolver" || item.name == "Revolver(Clone)") && itemInBar[0] == false)
            {
                foreach (Transform slot in transform)
                {
                    if (slot.GetComponent<Image>().sprite == blank)
                    {
                        slot.GetComponent<item>().activeItem = "revolver";
                        slot.GetComponent<Image>().sprite = revolver;
                        itemInBar[0] = true;
                        break;
                    }
                }
            }
            else if ((item.name == "BearTrap" || item.name == "BearTrap(Clone)") && itemInBar[1] == false)
            {
                foreach (Transform slot in transform)
                {
                    if (slot.GetComponent<Image>().sprite == blank)
                    {
                        itemInBar[1] = true;
                        slot.GetComponent<item>().activeItem = "bearTrap";
                        slot.GetComponent<Image>().sprite = bearTrap;
                        break;
                    }
                }
            }
        }
    }
}
