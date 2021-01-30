using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool selected;
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;

    void Update()
    {
        if(selected == true)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }

        if(Input.GetMouseButtonUp(0))
        {
            selected = false;
        }
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }
}
