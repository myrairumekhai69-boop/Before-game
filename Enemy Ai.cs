using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    public enum State { Idle, Patrol, Chase, Attack }
    public State currentState = State.Patrol;

    public Transform[] patrolPoints;
    public float chaseRange = 10f;
    public float attackRange = 2f;
    public float fieldOfView = 120f;

    NavMeshAgent agent;
    Transform player;
    int patrolIndex = 0;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        var p = GameObject.FindGameObjectWithTag("Player");
        if (p) player = p.transform;
    }

    void Update()
    {
        if (player == null) { DoPatrol(); return; }

        float dist = Vector3.Distance(transform.position, player.position);
        bool canSee = CanSeePlayer();

        if (dist <= attackRange && canSee) currentState = State.Attack;
        else if (dist <= chaseRange && canSee) currentState = State.Chase;
        else currentState = State.Patrol;

        switch (currentState)
        {
            case State.Patrol: DoPatrol(); break;
            case State.Chase: DoChase(); break;
            case State.Attack: DoAttack(); break;
            default: DoPatrol(); break;
        }
    }

    bool CanSeePlayer()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.forward, dir);
        if (angle > fieldOfView * 0.5f) return false;

        if (Physics.Raycast(transform.position + Vector3.up * 1.2f, dir, out RaycastHit hit, chaseRange))
        {
            if (hit.collider.CompareTag("Player")) return true;
        }
        return false;
    }

    void DoPatrol()
    {
        if (patrolPoints == null || patrolPoints.Length == 0) return;
        if (!agent.hasPath || agent.remainingDistance < 0.5f)
        {
            agent.SetDestination(patrolPoints[patrolIndex].position);
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
        }
    }

    void DoChase()
    {
        agent.SetDestination(player.position);
    }

    void DoAttack()
    {
        agent.SetDestination(transform.position); // stop moving
        // Attack handled by EnemyAttack component (if present)
        var attack = GetComponent<EnemyAttack>();
        if (attack) attack.TryAttack(player.gameObject);
    }
}
