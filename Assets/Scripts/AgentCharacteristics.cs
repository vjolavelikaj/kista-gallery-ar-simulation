using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


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
	public GameObject startButton;
	public Text numberOfAgentsText;

	private float startSpeed;
	private bool slowOrFaster;
	private float speedCheck;
	private Animator animator;
	private int numberOfTargets;
	private int currentTarget;
	private bool targetExists;
	Vector3 destination;
	Transform targetDestination;
	NavMeshAgent agent;

	void Start()
	{
		// Cache agent component and destination
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		destination = agent.destination;
		startSpeed = agent.speed;
		numberOfTargets = targetsGameObjects.Count;
		if (numberOfTargets == 0)
		{
			targetExists = false;
			exitGameObjects.Remove(startPoint);
			targetDestination = exitGameObjects[UnityEngine.Random.Range(0, exitGameObjects.Count)];
			agent.SetDestination(targetDestination.position);
		}
		else
		{
			targetExists = true;
			currentTarget = 0;
			targetDestination = targetsGameObjects[0];
			agent.SetDestination(targetDestination.position);
		}
	}

	void Update()
	{
		if (startButton.transform.transform.tag == "Pause")
		{

			startAnimation();

			// Update destination if the target moves one unit
			if (Vector3.Distance(destination, targetDestination.position) > 1)
			{
				destination = targetDestination.position;
				agent.destination = destination;
			}

			// Check if we've reached the destination
			// https://answers.unity.com/questions/324589/how-can-i-tell-when-a-navmesh-has-reached-its-dest.html
			// https://stackoverflow.com/questions/60810676/unity-navmesh-event-on-navigation-end
			if (agent.remainingDistance <= 1)
			{
				animator.runtimeAnimatorController = idle;
				StartCoroutine(stopSomeSeconds());

				if (targetExists)
				{
					if (numberOfTargets != 0 && currentTarget + 1 < numberOfTargets)
					{
						currentTarget++;
						targetDestination = targetsGameObjects[currentTarget];
					}
					else
					{
						targetExists = false;
						exitGameObjects.Remove(startPoint);
						targetDestination = exitGameObjects[UnityEngine.Random.Range(0, exitGameObjects.Count)];
					}

					agent.SetDestination(targetDestination.position);
				}
				else
				{
					Destroy(agent.gameObject, 1);
					agent.gameObject.SetActive(false);
				}

			}

			if (slowOrFaster)
			{
				agent.speed = startSpeed;
			}
		}
		else
		{
			stopAnimation();
		}
		
	}

	IEnumerator stopSomeSeconds()
	{
		stopAnimation();
		yield return new WaitForSeconds(2);
		startAnimation();
	}

	private void stopAnimation()
	{
		agent.isStopped = true;
		animator.runtimeAnimatorController = idle;
	}
	private void startAnimation()
	{
		agent.isStopped = false;
		animator.runtimeAnimatorController = movement;
	}

}