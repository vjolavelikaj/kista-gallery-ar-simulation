using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleNavigator : MonoBehaviour
{

    public GameObject bigScaleObject;
    public RuntimeAnimatorController idle, movement;

    private Vector3 bigScalePosition;
    private Animator bigAnimator;
    private Animator smallAnimator;

    void Start()
    {
        bigAnimator = bigScaleObject.GetComponent<Animator>();
        smallAnimator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (bigScaleObject.activeSelf)
        {
            smallAnimator.runtimeAnimatorController = bigAnimator.runtimeAnimatorController;
            bigScalePosition = bigScaleObject.transform.localPosition;
            this.transform.localPosition = bigScalePosition / 100f;
            
            this.transform.eulerAngles = bigScaleObject.transform.eulerAngles;
        }
        else
		{
            Destroy(this.gameObject, 1);
            this.gameObject.SetActive(false);
        }
    }
}
