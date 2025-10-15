using UnityEngine;
using UnityEngine.Events;

public class GameEventTrigger : MonoBehaviour
{
    [Header("Trigger Event Settings")]
    public UnityEvent onTriggerEvent;
    private bool hasFired = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasFired) return;
        if (other.CompareTag("Player"))
        {
            hasFired = true;
            onTriggerEvent?.Invoke();
            Debug.Log("Game event triggered: " + gameObject.name);
        }
    }
}
