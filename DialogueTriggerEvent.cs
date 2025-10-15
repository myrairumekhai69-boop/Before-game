using UnityEngine;

public class DialogueTriggerEvent : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public bool triggerOnce = true;
    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (!hasTriggered || !triggerOnce))
        {
            dialogueTrigger.TriggerDialogue();
            hasTriggered = true;
        }
    }
}
