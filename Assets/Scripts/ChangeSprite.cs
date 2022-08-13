using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite newClothes;
    [SerializeField] private Sprite oldClothes;
    
    //[SerializeField] private Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = newClothes;
        }
        
        if(Input.GetMouseButtonDown(1))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = oldClothes;
        }
    }
    
    
}
