using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class UIManager : MonoBehaviour
{
    //This script Make UI and Script Work together
    [SerializeField] private foodDecay _foodDecay;
    [SerializeField] private Image _hungerMeter;

    private void FixedUpdate()
    {
        _hungerMeter.fillAmount = _foodDecay.HungerPercent;
        
        
    }
}
