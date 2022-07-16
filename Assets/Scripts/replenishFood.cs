using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class replenishFood : MonoBehaviour
{
    //Restore foodbar and water bar
    [SerializeField] private float foodReplenish, etc;
    private void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    //Rotate Item 




    //Player interact with Item and destroy it
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //กันเหนียว
        if (!collider.gameObject.CompareTag("Player")) return;

        var foodDecay = collider.gameObject.GetComponent<foodDecay>();

        //กันเหนียวไว้ก่อน
        if (foodDecay is null) return;
        
        //put other replenish type
        foodDecay.ReplenishFood(foodReplenish, etc);
        Destroy(gameObject);
    }
}
