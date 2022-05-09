using System.Collections;
using UnityEngine;
using UnityEngine.AI;


//Leos destination implementation
[RequireComponent(typeof(NavMeshAgent))]
public class AgentCharacteristics : MonoBehaviour
{
    private float time = 0f;
    private float timeDelay = 3f;
    public Transform target;
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController movement;
    public bool destroyActive;

    private Animator animator;
    private bool nextTarget;

    Vector3 destination;
    NavMeshAgent agent;

    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        animator = GetComponent<Animator>();
        agent.SetDestination(target.position); 
    }
    

    void Update()
    {
         // Update destination if the target moves one unit
        if (Vector3.Distance(destination, target.position) > 0.01f)
        {
            destination = target.position;
            agent.destination = destination;
        }
        
        // Check if we've reached the destination
        // https://answers.unity.com/questions/324589/how-can-i-tell-when-a-navmesh-has-reached-its-dest.html
        // https://stackoverflow.com/questions/60810676/unity-navmesh-event-on-navigation-end
        if (agent.destination != destination) {
            animator.runtimeAnimatorController = movement;
        }
        if (agent.remainingDistance <= 0.02f) 
        {
            animator.runtimeAnimatorController = idle;
        }
        
        if (agent.remainingDistance <= 0.02f && agent.name.Contains("Clone") && destroyActive) {
            Destroy(agent.gameObject, 1);
            agent.gameObject.SetActive(false);

        }
    }

    void DelayTime()
    {
        time = time + 1f * Time.deltaTime;

        if (time >= timeDelay)
        {
            time = 0f;
        }
    }
    
    private void OnTriggerEnter(Collider other)                    
    {                                                              
        if(other.CompareTag("Door"))                          
        {                                                          
            agent.speed = agent.speed/2;  
            Debug.Log("Test");                                                           
        }                                                          
        
    }                                                              
    
}