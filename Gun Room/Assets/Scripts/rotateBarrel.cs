using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateBarrel : MonoBehaviour
{
    public Transform gun;
    Transform pivot;

    void Start()
    {
        pivot = gun.transform;
        transform.parent = pivot;

    }

    void Update()
    {
        Vector3 vector = Camera.main.WorldToScreenPoint(transform.parent.transform.position);
        vector = Input.mousePosition - vector;
        float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        pivot.position = gun.position;
        pivot.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
}
