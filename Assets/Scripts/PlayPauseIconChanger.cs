using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayPauseIconChanger : MonoBehaviour, IPointerDownHandler
{
	public Sprite play, playPressed, pause, pausePressed;
	private Button btn;

	void Start()
	{
		btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
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

	private String CheckCurrentImage()
	{
		return transform.transform.tag;
	}

	public void OnPointerDown(PointerEventData eventData)
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

}