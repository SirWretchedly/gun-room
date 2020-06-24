using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float hp = 5;

    private Animator status;
    private int damaged;

    void Start()
    {
        status = gameObject.transform.Find("Status").gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (GameObject.FindWithTag("Bullet") != null)
        {
            foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("Trap"))
            {
                if (Vector3.Distance(transform.position, bullet.transform.position) < 0.2)
                {
                    status.SetBool("damaged", true);
                    Destroy(bullet);
                    damaged = 100;
                    hp--;
                }
            }
        }
        if(damaged > 0)
        {
            damaged--;
        }
        else
        {
            status.SetBool("damaged", false);
        }
        if (hp <= 0)
        {
            status.SetBool("dead", true);
            Destroy(gameObject);
        }
    }
}
