using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Timers;

public class TimeScript : MonoBehaviour
{
    public AllGeyserScript geysers;
    private int time = 0;
    private float prevTime = 0;

    public void FixedUpdate()
    {
        float calculatedTime = prevTime + Time.fixedDeltaTime;
        if (Mathf.Floor(calculatedTime) > Mathf.Floor(prevTime))
        {
            time++;
            Debug.Log($"Time : {time}");
            geysers.ChangeGeyserState(time);
        }

        prevTime = calculatedTime;
    }


    void OnDisable()
    {

    }
}