using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTargetScalerSmall : MonoBehaviour
{
	public GameObject lowScaleObject;

	private Vector3 initialPosition;
	//private Vector3 rotationDiff;

	void Start()
	{
		initialPosition = transform.position;
		//rotationDiff = new Vector3(-90f, 0, 180f);
	}

	void Update()
	{
		transform.localPosition = (lowScaleObject.transform.localPosition / 10f) - initialPosition;
		//this.transform.eulerAngles = lowScaleObject.transform.eulerAngles + rotationDiff;
	}
}
