using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    public GameObject startButton;

    private Text textClock;
    private float timeStart;

    void Start()
    {
        textClock = GetComponent<Text>();
        timeStart = 0f;
    }

    void FixedUpdate()
    {
        if (startButton.transform.transform.tag == "Pause")
        {
            timeStart += Time.deltaTime;
        }

        textClock.text = timeStart.ToString("F2");
    }

	public void ResetTimer()
	{
        timeStart = 0f;
        textClock.text = timeStart.ToString("F2");
	}
}
