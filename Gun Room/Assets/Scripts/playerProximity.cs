using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProximity : MonoBehaviour
{
    public GameObject item;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 2)
        {
            gameObject.GetComponent<Animator>().SetBool("proximity", true);
            if(Input.GetKeyDown("e"))
            {
                Instantiate(item, player.transform);
                Destroy(gameObject);
            }
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("proximity", false);
        }
    }
}
