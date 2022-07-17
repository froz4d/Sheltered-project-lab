using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using UnityEngine.Events;
using Unity.UI;
using TMPro;
using Unity.VisualScripting;
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
    
    
    public Rigidbody2D rb;
    
   //food
   [SerializeField] private float _maxHunger;
   public float _currentHunger;
   [SerializeField] private float _hungerDepletionRate;
   public float HungerPercent => _currentHunger / _maxHunger;

   

   public float stoppingDistance;
   private Transform target;
  
    
    
   
    
  
    
    
    void Start()
    {
        waitTime = startWaitTime;

        moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        
        //food
        _currentHunger = _maxHunger;
        
        

        
    }

    //move character to random spot
    void Update()
    {
        
        
        transform.position = Vector2.MoveTowards(transform.position, moveSpots.position, speed * Time.deltaTime);
        
        //wait for the character to travel to the random location first
        if (Vector2.Distance(transform.position, moveSpots.position) < 5f)
        {
            if (waitTime <= 0)
            {
                waitTime = startWaitTime;
                moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                // return;
            }
            
            //this statement to make sure that time is slowly derease so that the Ai can move after waiting time
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (_currentHunger <= 50)
        {
            
            target = GameObject.FindGameObjectWithTag("foodReplenish").GetComponent<Transform>();
            if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                if (_currentHunger > 90)
                {
                    //To make sure it does not stay at the same position to prevent inappropriate fucntion
                    waitTime = startWaitTime;
                    moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    // return;
                }
                

            }
            
           

        }
        
        
        _currentHunger -= _hungerDepletionRate * Time.deltaTime;
        //foood

        if (_currentHunger <= 0)
        {
            _currentHunger = _hungerDepletionRate * Time.deltaTime;
        }
        
        


    }
    public void ReplenishFood(float hungerAmount, float etc)
    {
        _currentHunger += hungerAmount;
        if (_currentHunger > _maxHunger) _currentHunger = _maxHunger;
    }


}
