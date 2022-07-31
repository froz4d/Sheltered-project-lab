using TMPro;
using UnityEngine;

public class coinCount : MonoBehaviour
{
    //cheat scripts 
    //store coin in player pref(ฐานข้อมูล)

    public int _count;
    public TextMeshProUGUI TextMeshPro;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _count = PlayerPrefs.GetInt("amount");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            _count += 1;
            PlayerPrefs.SetInt("amount", _count);
        }
        
        TextMeshPro.text = "" + _count;
    }
    
}
