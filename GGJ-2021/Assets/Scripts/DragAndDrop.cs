using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool selected;
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;

    public Vector2 pos;
    public float speed = 1.0f;
    public GameObject quad;

    SoundHandler sound;

    void Start()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>(); // where item  slide
        float screenX = Random.Range(c.bounds.min.x, c.bounds.max.x); // random position on quad
        float screenY = Random.Range(c.bounds.min.y, c.bounds.max.y); // random position on quad
        //Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        pos = new Vector2(screenX, screenY);
        sound = GameObject.Find("Main Camera").GetComponent<SoundHandler>();
    }

    void Update()
    {
        if(selected == true)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPos.x, cursorPos.y);
        }

        if(Input.GetMouseButtonUp(0))
        {
            if (selected == true)
            {
                sound.PlaySound(4);
            }
            selected = false;
           
        }

        // items fly to Quad
        float step = speed * Time.deltaTime;
        transform.position = Vector2.Lerp(transform.position, pos, step);

    }


    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            selected = true;
            sound.PlaySound(3);
            sound.IntensifyMusic();
        }
    }

    // change color when clich
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = mouseOverColor;
        if (!Input.GetMouseButton(0))
        {
            sound.PlaySound(5);

        }
    }


    void OnMouseExit()
    {
        // only uncolor if not being dragged
        if(selected == false)
        {
            GetComponent<Renderer>().material.color = originalColor;
        }
    }
}
