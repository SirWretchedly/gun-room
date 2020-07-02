using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float hp = 5;

    private Animator status;
    private int damaged = 0;
    private GameObject bullet;
    public bool killed = false;

    void Start()
    {
        status = gameObject.transform.Find("Status").gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if(damaged > 0)
        {
            damaged--;
        }
        else
        {
            status.SetBool("damaged", false);
            if(killed == true)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (hp <= 0 && killed == false)
        {
            status.SetBool("dead", true);
            killed = true;
            gameObject.GetComponent<FollowPlayer>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.tag = "Corpse";
            gameObject.layer = 22;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Bullet")
        {
            status.SetBool("damaged", true);
            Destroy(collision.collider.gameObject);
            damaged = 40;
            hp--;
        }

    }


}
