using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerCursor : MonoBehaviour
{
    public Texture2D cursor;

    private void Start()
    {
        Vector2 hotSpot = new Vector2(cursor.width / 2f, cursor.height / 2f);
        Cursor.SetCursor(cursor, hotSpot, CursorMode.Auto);
    }
}
