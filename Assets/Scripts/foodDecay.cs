using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.UI;
using TMPro;

public class foodDecay : MonoBehaviour
{
    //Food 
    [SerializeField] private float _maxHunger;
    [SerializeField] private float _hungerDepletionRate;
    
    // [SerializeField] private patrol _survivalManager;
    // [SerializeField] private int _hungerMeter;
    public TextMeshProUGUI TextMeshPro;
    
    
    
    private float _currentHunger;
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
}
