using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crewmate : MonoBehaviour
{
    [SerializeField] private int maxHp;
    [SerializeField] private int maxHunger;
    [SerializeField] private WorkType status;
    [SerializeField] private int hungerTrigger;
    
    private int hp;
    private float hunger;
    
    public enum WorkType
    {
        idle,
        working,
        hungry,
        thirsty
    }
    
    // - Unity Execute Method -
    
    void Start()
    {
        hp = maxHp;
        hunger = maxHunger;
    }

    void Update()
    {
        Living();
    }
    
    // - Custom Method -

    private void Living()
    {
        hunger -= Time.deltaTime;
        
        if(hunger <= hungerTrigger) SetStatus(WorkType.hungry);
    }
    
    // - Public Method -

    public void SetStatus(WorkType type)
    {
        status = type;
    }
}
