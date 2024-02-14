using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeScript : MonoBehaviour
{
    private float firstTime = 0;
    private float lastTime = 0;
    public GeyserScript geysers;

    // Start is called before the first frame update
    void Start()
    {
        firstTime = Time.time;
        lastTime = firstTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time-lastTime == 1)
        {
            Debug.Log(Time.time);
            lastTime = Time.time;
            geysers.ChangeGeyserState((int)lastTime);
        }
    }
}
