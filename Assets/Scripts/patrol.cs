using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using UnityEngine.Events;
using Unity.UI;
using TMPro;
using Image = UnityEngine.UI.Image;



public class patrol : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;
    

    public Transform moveSpots;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    
  
    
    
   
    
  
    
    
    void Start()
    {
        waitTime = startWaitTime;

        moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        

        
    }

    //move character to random spot
    void Update()
    {
        
        
        transform.position = Vector2.MoveTowards(transform.position, moveSpots.position, speed * Time.deltaTime);
        
        //wait for the character to travel to the random location first
        if(Vector2.Distance(transform.position, moveSpots.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                waitTime = startWaitTime;
                moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            }
            // if (waitTime <= 0 && _currentHunger <= 50)
            // {
            //     waitTime = startWaitTime;
            //     moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            // }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }


    }


}
