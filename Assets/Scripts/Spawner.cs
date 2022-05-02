using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // this is the prefab which will be spawned
    public GameObject prefab;

    // this is ModelTarget object added from Vuforia menu
    public GameObject targetModel;

    // time interval in seconds to spawn cars
    public float interval = 5f;

    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCar",1f,interval);
    }

    private bool IsModelTracked() {
        return targetModel.GetComponentInChildren<MeshRenderer>().enabled;
    }

    private void SpawnCar() {
        if (IsModelTracked()) {
            Spawn();
        }
    }

    public void Spawn() {
        GameObject.Instantiate(prefab, targetModel.transform.position, targetModel.transform.rotation);
    }
}
