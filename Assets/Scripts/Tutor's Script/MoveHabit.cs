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

    private Vector2 target;
    
    //Walking-Related Variable
    private float x, y;
    private bool stop = false;

    #endregion

    #region - Unity Execute Method -
 
    private void Start()
    {
        RandomWaypoint();
    }

    private void Update()
    {
        if (targetObj == null)
        {
            MoveTo(waypoint);
        }
        else
        {
            MoveTo(target);
        }

        if (((Vector2) transform.localPosition == waypoint || (Vector2) transform.localPosition == target) && !stop)
        {
            Debug.Log("STOP!");
            StartCoroutine(Cooldown());
        }
    }

    #endregion

    #region - Custom Method -

    void MoveTo(Vector2 objective)
    {
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, objective, speed * Time.deltaTime);
    }

    void MoveTo(GameObject objective)
    {
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(objective.transform.localPosition.x, transform.localPosition.y), speed * Time.deltaTime);
    }
    
    void RandomWaypoint()
    {
        x = Random.Range(-_bokey.horizontalRadius, _bokey.horizontalRadius);
        switch (_bokey.type)
        {
            case BokeyProfile.TrainType.LowerDeck:
                y = _floor.FloorPlans[0].groundLevel;
                break;
            case BokeyProfile.TrainType.UpperDeck:
                y = _floor.FloorPlans[1].groundLevel;
                break;
        }
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

    IEnumerator Cooldown()
    {
        stop = true;
        SetTarget(null);
        yield return new WaitForSeconds(2f);
        RandomWaypoint();
    }

    #endregion
}
