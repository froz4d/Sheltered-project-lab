using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;




public class TemplateScript : MonoBehaviour
{
    
    //costumize the object final build
    [SerializeField] private GameObject finalObject;
    [SerializeField] private LayerMask allTilesLayer;
    
    [SerializeField] private GameObject afterdelay;

    
    //variable
    private Vector2 mousePos;
    
    //Build tick timer
    /*private int buildTick;
    private int buildTickMax;
    private bool isConstructing;

    private World_Bar constructingWorldBar;
    */




    
    void Update()
    {
        //stick selected object to the mouse 
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

        
        //Place the Object 
        if (Input.GetMouseButtonDown(0))
        {
            //Vector2 mouseRay = Camera.main.ScreenToWorldPoint(transform.position);
            //raycast from camera infinite
            RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity,allTilesLayer);
            StartCoroutine(delayConstruction());
            
            
           
            //If Place == null you can place object //check by using raycast
            if (rayHit.collider == null && this.gameObject.tag == "BoxTile" )
            {
                
                
                Instantiate(finalObject, transform.position, Quaternion.identity);
                
            }
            // Update is called once per frame
            
        }
    }
    
    IEnumerator delayConstruction()
    {
        yield return new WaitForSeconds(4f);
        Instantiate(afterdelay, transform.position, Quaternion.identity);
    }
    
    //Time tick constructing
    /*private void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        if (isConstructing)
        {
            buildTick += 1;
            if (buildTick >= buildTickMax)
            {
                //building is fully constructed
                isConstructing = false;
                constructingWorldBar.Hide();
            }
            else
            {
                //building is still under construction
                constructingWorldBar.SetSize(buildTick * 1f / buildTickMax);
            }
        }
    }
    */
}
