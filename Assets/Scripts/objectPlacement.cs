using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class objectPlacement : MonoBehaviour
{
    
    
    
    //coin
    public int count;
    public TextMeshProUGUI TextMeshPro;
    
    //costumize the object final build
    [SerializeField] private GameObject placeObject;
    [SerializeField] private LayerMask allTilesLayer;
    [SerializeField] private GameObject bluePrint;

    public ObjectScipts activeBlueprint;
    


    //variable
    private Vector2 mousePos;




    void Update()
    {
        //stick selected object to the mouse 
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));


        //Place the Object with mouse
        if (Input.GetMouseButtonDown(0))
        {
            
            //raycast from camera infinite
            RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity, allTilesLayer);

            if (count <= 0)
            {
                Debug.Log("Can;t place this Object");
                return;
            }

            // Check if there is Object so we can place object
            if (rayHit.collider == null && gameObject.CompareTag("objectTag") && count >= 0)
            {
                GameObject placedObject = Instantiate(bluePrint, transform.position, Quaternion.identity);
                
                Vector2 afterDelayPos = placedObject.transform.position;
                
                StartCoroutine(DelayConstruction(afterDelayPos, placedObject, activeBlueprint.delay));
                
                count -= 1;
            }
            // else
            // {
            //     Debug.Log("Yoinks");
            // }



        }
        TextMeshPro.text = "" + count;

    }
    IEnumerator DelayConstruction(Vector2 position, GameObject go, float otherDelay)
    {
        
        yield return new WaitForSeconds(otherDelay);
        Destroy(go);
        Instantiate(placeObject, position, Quaternion.identity);
    }
    
}
