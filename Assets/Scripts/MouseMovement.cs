using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 6f;
    Vector2 targetPos;

    private void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            targetPos.y = -3.2f; // Can change Y value
            
            target.position = targetPos;
            
            if((Vector2)transform.position != targetPos)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            }
        }
        
        if((Vector2)transform.position != targetPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        
    }
}

