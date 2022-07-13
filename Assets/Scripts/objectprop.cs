using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



[CreateAssetMenu(menuName = "build/object")]
public class objectprop : ScriptableObject
{
    [SerializeField] private string _name;

    public string name => _name;

    [SerializeField] private int _price;

    public int price => _price;
    
    public TextMeshProUGUI TextMeshPro;

    [SerializeField] private float _delay;

    public float delay => _delay;


    [SerializeField]
    private Types _type;

    public Types type => _type;
    public enum Types
    {
        foodStation, 
        waterStation,
        barStation,
        
        
    }

    
    
    
    

}
