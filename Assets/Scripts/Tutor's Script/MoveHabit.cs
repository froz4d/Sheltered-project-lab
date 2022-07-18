using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveHabit : MonoBehaviour
{
    #region - Variable Declare -

    [Header("Movement Setting")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private float stopDelay = 2f;

    [Header("Profile")]
    [SerializeField] private BokeyProfile _bokey; //Depend on bokey TODO: Apply to OnTriggerEnter
    [SerializeField] private FloorProfile _floor; //Main Profile Setting for Floor Plan
    
    private Vector2 _waypoint; //Waypoint for normal roaming
    public Vector2 waypoint => _waypoint; //In case of other class need to check use this
    
    [SerializeField]private GameObject targetObj; //Override waypoint by target
    [SerializeField] private GameObject _dummyTarget;
    public GameObject dummyTarget => _dummyTarget;
    [SerializeField] private Rigidbody2D rb;

    private Vector2 ladderPosition;

    private Vector2 target;

    [Header("System Disable Panel")] [SerializeField]
    private bool destinationCheck = false;
    
    //Walking-Related Variable
    private float x, y;
    private bool stop = false;

    //Elevate-Related
    [Header("Debug Menu")]
    [SerializeField]private bool needLadder = false;
    [SerializeField]private elevateMode elevateRequirement = elevateMode.None;
    [SerializeField]private bool climbing = false;
    
    public enum elevateMode
    {
        Up,
        None,
        Down
    }
    
    #endregion

    #region - Unity Execute Method -
 
    private void Start()
    {
        RandomWaypoint();
    }

    private void Update()
    {
        if(!climbing) MovingBehavior();
        else if (climbing) ClimbingBehavior();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder") && needLadder)
        {
            climbing = true;
            ClearParent();
            ladderPosition = new Vector2(transform.position.x, transform.position.y);
            switch (elevateRequirement)
            {
                case elevateMode.Up:
                    ladderPosition.y = _floor.worldGroundLevel[1];
                    break;
                case elevateMode.Down:
                    ladderPosition.y = _floor.worldGroundLevel[0];
                    break;
            }

            // rb.constraints = RigidbodyConstraints2D.None;
            // rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    #endregion

    #region - Custom Method -

    void MovingBehavior()
    {
        if (targetObj == null)
        {
            MoveTo(waypoint);
        }
        else
        {
            MoveTo(target);
        }

        if(!destinationCheck) 
            if (((Vector2) transform.localPosition == waypoint || (Vector2) transform.localPosition == target) && !stop)
            {
                Debug.Log("STOP!");
                StartCoroutine(Cooldown());
            }
    }

    void ClimbingBehavior()
    {
        MoveTo(ladderPosition);

        if ((Vector2) transform.localPosition == ladderPosition)
        {
            climbing = false;
            needLadder = false;
        }
    }

    void MoveTo(Vector2 objective) //Move to Position Command
    {
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, objective, speed * Time.deltaTime);
    }

    // void MoveTo(GameObject objective) //Variant of Move to Position Command By use GameObject
    // {
    //     transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(objective.transform.localPosition.x, transform.localPosition.y), speed * Time.deltaTime);
    // }
    
    void RandomWaypoint()
    {
        x = Random.Range(-_bokey.horizontalRadius, _bokey.horizontalRadius);
        //if (transform.parent != null)
        //{
            switch (_bokey.type)
            {
                case BokeyProfile.TrainType.LowerDeck:
                    y = _floor.localGroundLevel;
                    break;
                case BokeyProfile.TrainType.UpperDeck:
                    y = _floor.localGroundLevel;
                    break;
            }
        //}
            
        OverrideWaypoint(x,y);
        stop = false;
    }

    public void OverrideWaypoint(float posX, float posY)
    {
        _waypoint = new Vector2(posX, posY);
    }

    public void SetTarget(GameObject moveTo)
    {
        targetObj = moveTo;
        if (targetObj != null) target = new Vector2(targetObj.transform.localPosition.x, transform.localPosition.y);
        else target = Vector2.zero;
    }

    public void SetParent(GameObject parent)
    {
        transform.SetParent(parent.transform);
    }

    public void ClearParent()
    {
        transform.SetParent(null);
    }

    IEnumerator Cooldown()
    {
        stop = true;
        SetTarget(null);
        yield return new WaitForSeconds(2f);
        RandomWaypoint();
    }

    #endregion
}
