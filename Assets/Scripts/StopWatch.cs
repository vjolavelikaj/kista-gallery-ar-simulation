using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    private Text textClock;
    private float timeStart;

    void Start()
    {
        textClock = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        timeStart += Time.deltaTime;
        textClock.text = timeStart.ToString("F2");
    }
}
