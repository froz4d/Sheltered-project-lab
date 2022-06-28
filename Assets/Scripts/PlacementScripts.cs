using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class PlacementScripts : MonoBehaviour
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
        selectedObjectInArray = 0;
        
        //CodeMonkey code
        TimeTickSystem.OnTick += delegate(object sender, TimeTickSystem.OnTickEventArgs e)
        {
            CMDebug.TextPopupMouse("tick: " + e.tick);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
        //Make it placetable and stick to the Grid By round it
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 spawnPos = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
        
        //If select E key it will select your object
        if (Input.GetKeyDown("e") && isAnObjectSelected == false)
        {
            //If press E key select Object
            currentlySelectedObject =
                (GameObject)Instantiate(selectableObjects[selectedObjectInArray], spawnPos, Quaternion.identity);
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
            currentlySelectedObject =
                (GameObject)Instantiate(selectableObjects[selectedObjectInArray], spawnPos, Quaternion.identity);
            
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
            currentlySelectedObject =
                (GameObject)Instantiate(selectableObjects[selectedObjectInArray], spawnPos, Quaternion.identity);
            
        }
        
    }



}       
    
