using UnityEngine;



[CreateAssetMenu(menuName = "build/object")]
public class objectproperties : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private float _delay;
    [SerializeField] private Types _type;
    
    public string name => _name;
    public int price => _price;
    public float delay => _delay;
    public Types type => _type;
    
    
    
    
    
    public enum Types
    {
        foodStation, 
        waterStation,
        barStation,
        bogey,
        
        
    }

    
    

}
