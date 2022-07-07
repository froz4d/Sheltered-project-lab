using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkHabit : MonoBehaviour
{
    [Header("Player")]
    
    public static List<WalkHabit> moveableObjects = new List<WalkHabit>();
    public float speed = 5f;

    private Vector2 target;
    private bool selected;
   [SerializeField] private SpriteRenderer spriteRenderer;
   
   
   
   [Space(10)] 
   
   [Header("WallCheck")]
   
   private int range = 2;
   
  
   
   
    

    // Start is called before the first frame update
    void Start()
    {
        moveableObjects.Add(this);
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        StopWalking();
        Debug.DrawRay(transform.position,transform.right * range,Color.red);
        if (Input.GetMouseButtonDown(1) && selected)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.y = -3.2f; // Can change Y value
        }

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        selected = true;
        spriteRenderer.GetComponent<SpriteRenderer>().color = Color.green;

        foreach (WalkHabit obj in moveableObjects)
        {
            if (obj != this)
            {
                obj.selected = false;
                obj.spriteRenderer.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
    
    private void StopWalking()
    {
        RaycastHit2D hit;
        if (Physics2D.Raycast(transform.position,Vector2.right))
        {
            
        }
        
    }
}
