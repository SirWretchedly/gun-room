using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteOffScreen : MonoBehaviour
{
    public Vector2 positionScreen;   

    void Update()
    {
        positionScreen = Camera.main.WorldToScreenPoint(transform.position);
        if (positionScreen.x > Screen.width || positionScreen.y > Screen.height || positionScreen.x < 0 || positionScreen.y < 0)
            Destroy(gameObject);
    }
}
