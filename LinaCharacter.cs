using UnityEngine;
using UnityEngine.AI;

public class LinaCharacter : MonoBehaviour
{
    [Header("Character Settings")]
    public string characterName = "Lina";
    public float moveSpeed = 2.5f;
    public float rotationSpeed = 5f;
    public float lookRadius = 10f;

    [Header("References")]
    public Animator animator;
    public NavMeshAgent agent;
    public Transform target;

    void Start()
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        if (animator == null) animator = GetComponent<Animator>();
        
        agent.speed = moveSpeed;
        agent.angularSpeed = rotationSpeed * 100;
    }

    void Update()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
