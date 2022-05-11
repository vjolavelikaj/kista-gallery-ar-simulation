using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	// This is ModelTarget object added from Vuforia menu
	public GameObject targetModel;

	// Time interval in seconds to spawn cars
	public float interval = 5f;

	// Possible characters to spawn
	public List<GameObject> charGameObjects = new List<GameObject>();

	// Possible starting points
	public List<Transform> startGameObjects = new List<Transform>();

	// Transform agentPosition;
	GameObject character;

	// Transform startPosition;
	Transform startPosition;

	private AgentCharacteristics agentCharacteristics;

	// Start is called before the first frame update
	void Start()
	{
		InvokeRepeating("SpawnChar", 1f, interval);
	}

	private bool IsModelTracked()
	{

		return targetModel.GetComponentInChildren<MeshRenderer>().enabled;

	}

	private void SpawnChar()
	{
		if (IsModelTracked())
		{
			Spawn();
		}
	}

	public void Spawn()
	{
		character = charGameObjects[Random.Range(0, charGameObjects.Count)];
		startPosition = startGameObjects[Random.Range(0, startGameObjects.Count)];
		var iniCharacter = GameObject.Instantiate(character, startPosition.position, startPosition.rotation);
		agentCharacteristics = iniCharacter.GetComponent<AgentCharacteristics>();
		agentCharacteristics.startPoint = startPosition;
	}
}
