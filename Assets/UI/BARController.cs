using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class BARController : MonoBehaviour
{
    [SerializeField] private Transform finishPoint;
    [SerializeField] private Slider slider;
    
    [SerializeField] private Transform player;

    private void Start()
    {
        slider.minValue = player.transform.position.z;
        slider.maxValue = finishPoint.transform.position.z;
    }

    private void FixedUpdate()
    {
        slider.value = player.transform.position.z;
    }
}
