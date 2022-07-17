using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloorPlan
{
    public int floorLevel;
    public float groundLevel;
}

[CreateAssetMenu(menuName = "Setting/Floor Plan")]
public class FloorProfile : ScriptableObject
{
    public FloorPlan[] FloorPlans;
}
