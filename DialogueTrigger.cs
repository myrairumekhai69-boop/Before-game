using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    [TextArea(2,5)]
    public string[] dialogueLines;
    public DialogueSystem dialogueSystem;

    public void OnInteract()
    {
        dialogueSystem.StartDialogue(dialogueLines);
    }
}
