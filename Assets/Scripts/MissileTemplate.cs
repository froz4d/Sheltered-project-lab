using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTemplate : MonoBehaviour
{
    //costumize the object final build
    [SerializeField] private GameObject finalObject;
    [SerializeField] private LayerMask allTilesLayer;


    //variable
    private Vector2 mousePos;



    void Update()
    {
        //stick selected object to the mouse 
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));


        //Place the Object 
        if (Input.GetMouseButtonDown(0))
        {
            
            //raycast from camera infinite
            RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity, allTilesLayer);



            // Update is called once per frame
            if (rayHit.collider == null && this.gameObject.tag == "StoneTile")
            {
                Instantiate(finalObject, transform.position, Quaternion.identity);
                //Debug.Log("You did not place object");
            }

        }
    }
}
