using UnityEngine;
using UnityEngine.AI;

public class NPCPanicTrigger : MonoBehaviour
{
    public Transform[] runPoints;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Panic()
    {
        if (runPoints.Length > 0)
        {
            int randomPoint = Random.Range(0, runPoints.Length);
            agent.SetDestination(runPoints[randomPoint].position);
        }
    }
}
