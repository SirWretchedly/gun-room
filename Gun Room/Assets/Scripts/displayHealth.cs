using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayHealth : MonoBehaviour
{
    public int count;
    public Sprite[] status;

    private Health playerHP;
    private Image image;

    void Start()
    {
        playerHP = GameObject.FindWithTag("Player").GetComponent<Health>();
        image = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (playerHP.hp < count * 3)
        {
            if(playerHP.hp + 1 == count * 3)
            {
                image.sprite = status[0];
            }
            else if(playerHP.hp + 2 == count * 3)
            {
                image.sprite = status[1];
            }
            else if(playerHP.hp + 3 == count * 3)
            {
                image.sprite = status[2];
            }
        }
    }
}
