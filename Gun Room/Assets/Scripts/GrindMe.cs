using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindMe : MonoBehaviour
{
    public float distance;

    private Print printer;

    private void Start()
    {
        printer = GameObject.Find("Printer").GetComponent<Print>();
    }

    void Update()
    {
        foreach(GameObject grinder in GameObject.FindGameObjectsWithTag("Grinder"))
        {
            if (Vector3.Distance(transform.position, grinder.transform.position) < distance)
            {
                if (gameObject.tag == "RZ")
                {
                    gameObject.GetComponent<TakeDamage>().hp--;
                }
                else if (gameObject.tag == "Corpse")
                {
                    Destroy(gameObject);
                    printer.flesh += 2;
                    printer.scrap += 1;
                }
                else if (gameObject.tag == "Player")
                {
                    if (gameObject.GetComponent<Health>().invincibility <= 0)
                    {
                        gameObject.GetComponent<Health>().hp--;
                        gameObject.GetComponent<Health>().invincibility = 100;
                        printer.flesh += 1;
                    }
                }
                else if(gameObject.name == "groundedRevolver" || gameObject.name == "groundedRevolver(Clone)")
                {
                    Destroy(gameObject);
                    printer.scrap += 10;
                }
                else if (gameObject.name == "groundedTrap" || gameObject.name == "groundedTrap(Clone)")
                {
                    Destroy(gameObject);
                    printer.scrap += 5;
                }
            }
        }
    }
}
