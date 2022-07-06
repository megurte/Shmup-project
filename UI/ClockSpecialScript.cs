using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Kirin;
using UnityEngine;

public class ClockSpecialScript : MonoBehaviour
{
    public GameObject hourArrow;
    public GameObject minuteArrow;
            
    public float timeRemaining = 0;

    private readonly float _delayHourArrow = 1f;
    private float _delayTimer = default;
    
    void Start()
    {
        _delayTimer = _delayHourArrow;
    }

    void FixedUpdate()
    {
        TimerRun();

        if (timeRemaining <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void TimerRun()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            minuteArrow.transform.Rotate(new Vector3(0, 0, -360) * Time.deltaTime);

            hourArrow.transform.Rotate(_delayTimer == _delayHourArrow ? new Vector3(0, 0, -30) : new Vector3(0, 0, 0));

            _delayTimer-= Time.deltaTime;

            if (_delayTimer <= 0)
                _delayTimer = _delayHourArrow;
        }
    }
}
