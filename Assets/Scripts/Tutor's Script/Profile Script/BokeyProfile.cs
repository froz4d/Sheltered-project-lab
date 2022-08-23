using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Profile/Train Space")]
public class BokeyProfile : ScriptableObject
{
    [SerializeField] private TrainType _type;
    public TrainType type => _type;

    [SerializeField] private float _horizontalRadius;
    public float horizontalRadius => _horizontalRadius;
    
    [SerializeField] private float _verticalRadius;
    public float verticalRadius => _verticalRadius;
    
    public enum TrainType
    {
        LowerDeck,
        UpperDeck
    }
}
