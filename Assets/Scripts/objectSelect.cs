using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;


public class objectSelect : MonoBehaviour
{

    private int selectedObjectInArray;
    private GameObject currentlySelectedObject;

    //set array
    [SerializeField] private GameObject[] selectableObjects;
    
    //automatically set to false
    private bool isAnObjectSelected = false;

    

    // Start selecting none object
    void Start()
    {
        //set array = 0;
        selectedObjectInArray = 0;
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Make it place able and stick to the Grid By round it
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 spawnPos = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
        

        
        //If select E key it will select your object เข้าสู่โหมดการส้ราง
        if (Input.GetKeyDown("e") && isAnObjectSelected == false)
        {
            //If press E key select Object
            currentlySelectedObject = Instantiate(selectableObjects[selectedObjectInArray], spawnPos, Quaternion.identity);
            isAnObjectSelected = true;
            
        }

        
        //Unselect the object from E key by "Right click"
        if (Input.GetMouseButtonDown(1) && isAnObjectSelected == true)
        {
            Destroy(currentlySelectedObject);
            isAnObjectSelected = false;
            selectedObjectInArray = 0;
        }
        
        
        //Mouse Scroll Wheel to pick array >0 
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && isAnObjectSelected == true)
        {
            selectedObjectInArray++;
                
            if (selectedObjectInArray > selectableObjects.Length - 1)
            {
                selectedObjectInArray = 0;
                

            }
            
            //change the item that we select to the next one
            Destroy(currentlySelectedObject);
            currentlySelectedObject = Instantiate(selectableObjects[selectedObjectInArray], spawnPos, Quaternion.identity);
            
        }
        
        //Mouse Scroll Wheel to pick array <0
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && isAnObjectSelected == true)
        {
            selectedObjectInArray--;
            
            if (selectedObjectInArray < 0)
            {
                selectedObjectInArray = selectableObjects.Length - 1;
                
            }
            //change the item that we select to the next one
            Destroy(currentlySelectedObject);
            currentlySelectedObject = Instantiate(selectableObjects[selectedObjectInArray], spawnPos, Quaternion.identity);
            
        }
        
        
    }


    
}       
    
