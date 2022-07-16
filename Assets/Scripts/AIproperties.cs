using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



[CreateAssetMenu(menuName = "AI properties")]
public class AIproperties : ScriptableObject
{
    [SerializeField] private string _name;

    public string name => _name;

    [SerializeField] private int _fooddecay;

    public int fooddecay => _fooddecay;
    
    public TextMeshProUGUI TextMeshPro;
    


    [SerializeField]
    private Types _type;

    public Types type => _type;
    public enum Types
    {
        AIJason, 
        AIAlfred,
        AIPekky,
        
        
    }

    
    
    
    

}
