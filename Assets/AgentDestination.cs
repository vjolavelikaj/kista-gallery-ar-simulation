using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AgentDestination : MonoBehaviour
{
    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;
    
    
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController movement;
    private Animator animator;

    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Update destination if the target moves one unit
        if (Vector3.Distance(destination, target.position) > 0.05f)
        {
            destination = target.position;
            agent.destination = destination;
        }
        
        // Check if we've reached the destination
        // https://answers.unity.com/questions/324589/how-can-i-tell-when-a-navmesh-has-reached-its-dest.html
        // https://stackoverflow.com/questions/60810676/unity-navmesh-event-on-navigation-end
        
        if (agent.destination != destination) {
            animator.runtimeAnimatorController = movement;
            Debug.Log("Worked");
        }
        if (agent.remainingDistance <= 0.05f) 
        {
            animator.runtimeAnimatorController = idle;
        }
        
    }
}