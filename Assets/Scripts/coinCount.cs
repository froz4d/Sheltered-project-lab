using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class coinCount : MonoBehaviour
{

    public int count = 100;
    public TextMeshProUGUI TextMeshPro;
    
    
    // Start is called before the first frame update
    void Start()
    {
        count = PlayerPrefs.GetInt("amount");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            count += 1;
            PlayerPrefs.SetInt("amount", count);
        }
        if (Input.GetMouseButtonDown(0))
        {
            count -= 1;
            PlayerPrefs.SetInt("amount", count);
        }


        TextMeshPro.text = "" + count;
    }
    
}
