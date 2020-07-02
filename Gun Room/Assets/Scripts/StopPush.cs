using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPush : MonoBehaviour
{
    private Rigidbody2D body;

    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        body.velocity = Vector2.zero;
        body.angularVelocity = 0;
    }
}
