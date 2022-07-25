using UnityEngine;
using Vector2 = UnityEngine.Vector2;




public class patrol : MonoBehaviour
{
    
    //AI properties
    public float speed;
    public float startWaitTime;
    private float _waitTime;
    
    //movement 
    public Transform moveSpots;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    private Transform _target;
    
    
   //food
   [SerializeField] private float _hungerDepletionRate;
   [SerializeField] private float _maxHunger;
   public float _currentHunger;
   public float HungerPercent => _currentHunger / _maxHunger;
   public Rigidbody2D rb;
   

   public float stoppingDistance;
   
  
    
    
   
    
  
    
    
    void Start()
    {
        _waitTime = startWaitTime;

        moveSpots.position = new Vector2(Random.Range(minX, maxX),Random.Range(minY, maxY));
        
        //food
        _currentHunger = _maxHunger;
        
        

        
    }

    //move character to random spot
    void Update()
    {
        
        
        transform.position = Vector2.MoveTowards(transform.position, moveSpots.position, speed * Time.deltaTime);
        
        //wait for the character to travel to the random location first
        if (Vector2.Distance(transform.position, moveSpots.position) < 10f)
        {
            if (_waitTime <= 0)
            {
                _waitTime = startWaitTime;
                moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                // return;
            }
            
            //this statement to make sure that time is slowly derease so that the Ai can move after waiting time
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }
        if (_currentHunger <= 50)
        {
            
            _target = GameObject.FindGameObjectWithTag("foodReplenish").GetComponent<Transform>();
            if(Vector2.Distance(transform.position, _target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
                if (_currentHunger > 90)
                {
                    //To make sure it does not stay at the same position to prevent inappropriate fucntion
                    _waitTime = startWaitTime;
                    moveSpots.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    // return;
                }
                

            }
            
           

        }
        
        
        _currentHunger -= _hungerDepletionRate * Time.deltaTime;
        //foood

        if (_currentHunger <= 0)
        {
            _currentHunger = _hungerDepletionRate * Time.deltaTime;
        }
        
        


    }
    public void ReplenishFood(float hungerAmount, float etc)
    {
        _currentHunger += hungerAmount;
        if (_currentHunger > _maxHunger) _currentHunger = _maxHunger;
    }


}
