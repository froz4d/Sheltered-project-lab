using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPlacement : MonoBehaviour
{
    //costumize the object final build
    [SerializeField] private GameObject placeObject;
    [SerializeField] private LayerMask allTilesLayer;
    [SerializeField] private GameObject bluePrint;


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
            if (rayHit.collider == null && gameObject.CompareTag("objectTag"))
            {
                GameObject placedObject = Instantiate(bluePrint, transform.position, Quaternion.identity);
                //Debug.Log("You did not place object");
                Vector2 afterDelayPos = placedObject.transform.position;
                
                StartCoroutine(DelayConstruction(afterDelayPos, placedObject));
            }
            
            
            // if (rayHit.collider == null && gameObject.CompareTag("platformTag"))
            // {
            //     GameObject placedObject = Instantiate(bluePrint, transform.position, Quaternion.identity);
            //     //Debug.Log("You did not place object");
            //     Vector2 afterDelayPos = placedObject.transform.position;
            //     
            //     StartCoroutine(DelayConstruction(afterDelayPos, placedObject));
            // }

        }
    }
    IEnumerator DelayConstruction(Vector2 position, GameObject go)
    {
        yield return new WaitForSeconds(2f);
        Destroy(go);
        Instantiate(placeObject, position, Quaternion.identity);
    }
    //
}
