using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;


//Leos destination implementation
[RequireComponent(typeof(NavMeshAgent))]
public class AgentCharacteristics : MonoBehaviour
{
    
    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;
    
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController movement;
    private Animator animator;

    public bool destroyActive;
    private float startSpeed;
    private bool slowOrFaster;
    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        animator = GetComponent<Animator>();
        agent.SetDestination(target.position);
        startSpeed = agent.speed;

    }

    void Update()
    {
        // Update destination if the target moves one unit
        if (Vector3.Distance(destination, target.position) > 1)
        {
            destination = target.position;
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
        
        if (agent.remainingDistance <= 6 && agent.name.Contains("(Clone)") && destroyActive) {
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
        if(other.CompareTag("NormalDoor"))
        { 
            agent.speed /= 2;
            slowOrFaster = true;
        }
        
        if(other.CompareTag("AutoDoor"))
        { 
            agent.speed *= 2;
            slowOrFaster = true;
        }
        

    }                                                              
   

}