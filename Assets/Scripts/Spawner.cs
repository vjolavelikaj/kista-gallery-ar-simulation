using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // this is the prefab which will be spawned
    // public GameObject prefab;

    // this is ModelTarget object added from Vuforia menu
    public GameObject targetModel;

    // time interval in seconds to spawn cars
    public float interval = 5f;
    
    public List<GameObject> charGameObjects = new List<GameObject>();
   // public List<GameObject> destGameObjects = new List<GameObject>();

   // Transform agentPosition;
    GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnChar",1f,interval);
    }

    private bool IsModelTracked() {

        return targetModel.GetComponentInChildren<MeshRenderer>().enabled;

    }

    private void SpawnChar() {
        if (IsModelTracked()) {
            Spawn();
        }
    }

    public void Spawn() {
        character = charGameObjects[Random.Range(0, charGameObjects.Count)];
        GameObject.Instantiate(character, targetModel.transform.position, character.transform.rotation);
    }
}
