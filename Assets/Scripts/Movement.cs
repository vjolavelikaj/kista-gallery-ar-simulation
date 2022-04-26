using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = .1f;

    // Update is called once per frame
    void Update() {
        MoveForward(); 
    }

    void MoveForward() {
        float step = Time.deltaTime * speed;
        transform.Translate(-transform.up * step, Space.World);
    }
}
