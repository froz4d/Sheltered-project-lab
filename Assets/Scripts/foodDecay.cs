using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class foodDecay : MonoBehaviour

{
    //Food 
    [SerializeField] private float _maxHunger;
    [SerializeField] private float _hungerDepletionRate;
    
    // [SerializeField] private patrol _survivalManager;
    // [SerializeField] private int _hungerMeter;
    //food
    public AIproperties fooddecay;
    
    
    public float HungerPercent => _currentHunger / _maxHunger;
    
    //[]serealizeField private instead
    public float _currentHunger;
    // public float HungerPercent => _currentHunger / _maxHunger;
    void Start()
    {
        //food
        _currentHunger = _maxHunger;
        
    }

    // Update is called once per frame
    void Update()
    {
        //foood
        _currentHunger -= _hungerDepletionRate * Time.deltaTime;
        
    }
    
    public void ReplenishFood(float hungerAmount, float etc)
    {
        _currentHunger += hungerAmount;
        if (_currentHunger > _maxHunger) _currentHunger = _maxHunger;
    }

    
}
