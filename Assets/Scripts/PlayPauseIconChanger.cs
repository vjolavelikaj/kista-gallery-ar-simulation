using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayPauseIconChanger : MonoBehaviour
{
	public Sprite play, playPressed, pause, pausePressed;
	private Button btn;

	void Start()
	{
		btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		//btn.OnPointerDown.AddListener(OnSelect);
	}

	void TaskOnClick()
	{
		if (CheckCurrentImage() == "Play")
		{
			GetComponent<Image>().sprite = pause;
			transform.transform.tag = "Pause";
		}
		else
		{
			GetComponent<Image>().sprite = play;
			transform.transform.tag = "Play";
		}
	}

	public void OnSelect() //NEEDS TO BE CHANGED!!! WORKS ONLY ONCE
	{
		if (CheckCurrentImage() == "Play")
		{
			GetComponent<Image>().sprite = playPressed;
		}
		else
		{
			GetComponent<Image>().sprite = pausePressed;
		}
	}

	private String CheckCurrentImage()
	{
		return transform.transform.tag;
	}

}