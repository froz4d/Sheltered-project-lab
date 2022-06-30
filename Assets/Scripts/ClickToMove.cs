using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public static List<ClickToMove> moveableObjects = new List<ClickToMove>();
    public float speed = 5f;

    private Vector2 target;
    private bool selected;
    

    // Start is called before the first frame update
    void Start()
    {
        moveableObjects.Add(this);
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && selected)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.y = -3.2f; // Can change Y value
        }

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        selected = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;

        foreach (ClickToMove obj in moveableObjects)
        {
            if (obj != this)
            {
                obj.selected = false;
                obj.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
