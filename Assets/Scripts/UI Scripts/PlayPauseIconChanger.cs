using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayPauseIconChanger : MonoBehaviour, IPointerDownHandler
{
	public Sprite play, playPressed, pause, pausePressed;
	public GameObject spawnerGameObject;

	private Spawner spawner;
	private Button btn;
	private bool fistTimeStart;

	void Start()
	{
		spawner = spawnerGameObject.GetComponent<Spawner>();
		btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

		fistTimeStart = true;
	}

	void TaskOnClick()
	{
		if (CheckCurrentImage() == "Play")
		{
			GetComponent<Image>().sprite = pause;
			transform.transform.tag = "Pause";
			if (fistTimeStart)
			{
				for (int i = 0; i < 10; i++)
				{
					spawner.SpawnChar();
				}

				fistTimeStart = false;
			}
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
	public void ResetButton()
	{
		GetComponent<Image>().sprite = play;
		transform.transform.tag = "Play";
		fistTimeStart = true;
	}

}