using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//Leos destination implementation
[RequireComponent(typeof(NavMeshAgent))]
public class AgentCharacteristics : MonoBehaviour
{
	[HideInInspector] public Transform startPoint;

	public List<Transform> targetsGameObjects = new List<Transform>();
	public List<Transform> exitGameObjects = new List<Transform>();
	public RuntimeAnimatorController idle;
	public RuntimeAnimatorController movement;
	public bool destroyActive;

	private float startSpeed;
	private bool slowOrFaster;
	private float speedCheck;
	private Animator animator;
	private bool targetExists = true;
	Vector3 destination;
	NavMeshAgent agent;
	Transform targetDestination;

	void Start()
	{
		// Cache agent component and destination
		agent = GetComponent<NavMeshAgent>();
		destination = agent.destination;
		animator = GetComponent<Animator>();
		startSpeed = agent.speed;

		if (targetsGameObjects.Count == 0)
		{
			targetExists = false;
			//exitGameObjects.Remove(startPoint);
			targetDestination = exitGameObjects[UnityEngine.Random.Range(0, exitGameObjects.Count)];
			agent.SetDestination(targetDestination.position);
		}
		else
		{
			targetDestination = targetsGameObjects[0];
			agent.SetDestination(targetDestination.position);
		}
	}

	void Update()
	{
		// Update destination if the target moves one unit
		if (Vector3.Distance(destination, targetDestination.position) > 1)
		{
			destination = targetDestination.position;
			agent.destination = destination;
			animator.runtimeAnimatorController = movement;
		}

		// Check if we've reached the destination
		// https://answers.unity.com/questions/324589/how-can-i-tell-when-a-navmesh-has-reached-its-dest.html
		// https://stackoverflow.com/questions/60810676/unity-navmesh-event-on-navigation-end
		if (agent.remainingDistance <= 4)
		{
			animator.runtimeAnimatorController = idle;
		}

		//Getting the clone agent destroy
		if (agent.remainingDistance <= 6 && agent.name.Contains("(Clone)") && destroyActive)
		{
			Destroy(agent.gameObject, 1);
			agent.gameObject.SetActive(false);
		}

		if (slowOrFaster)
		{
			agent.speed = startSpeed;
		}
	}

	private void OnTriggerEnter(Collider other)
	{

		if (other.CompareTag("SlowDown"))
		{
			agent.speed /= 2;
		}

		if (other.CompareTag("NormalDoor"))
		{
			StartCoroutine("waitSomeSeconds");
		}

		if (other.CompareTag("SpeedUp"))
		{
			agent.speed *= 2;
		}

		if (other.CompareTag("AutoDoor"))
		{
			StartCoroutine("waitSomeSeconds");
		}
	}

	IEnumerator waitSomeSeconds()
	{
		yield return new WaitForSeconds(1);
		slowOrFaster = true;
	}
}