using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProximity : MonoBehaviour
{
    public GameObject trap;
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 1.3)
        {
            gameObject.GetComponent<Animator>().SetBool("proximity", true);
            if(Input.GetKeyDown("e"))
            {
                Instantiate(trap, player.transform);
                Destroy(gameObject);
            }
        }
        else
            gameObject.GetComponent<Animator>().SetBool("proximity", false);
    }
}
