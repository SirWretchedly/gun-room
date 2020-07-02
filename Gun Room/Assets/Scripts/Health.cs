using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP = 3;
    public int hp;
    public int invincibility = 0;

    void Start()
    {
        hp = maxHP;
    }

    void Update()
    {
        if(invincibility > 0)
        {
            invincibility--;
        }
        else
        {
            foreach (GameObject RZ in GameObject.FindGameObjectsWithTag("RZ"))
            {
                if (Vector3.Distance(RZ.transform.position, gameObject.transform.position) < 0.5)
                {
                    hp--;
                    invincibility = 100;
                }
            }
        }
        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void TakeDamage()
    { 
}
}
