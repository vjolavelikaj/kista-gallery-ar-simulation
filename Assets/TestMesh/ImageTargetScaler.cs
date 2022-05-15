using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTargetScaler : MonoBehaviour
{
    public GameObject lowScaleObject;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = lowScaleObject.transform.localPosition * 100f;
    }
}
