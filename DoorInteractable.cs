using UnityEngine;

public class DoorInteractable : MonoBehaviour, IInteractable
{
    public Animator doorAnimator;
    private bool isOpen = false;

    public void OnInteract()
    {
        isOpen = !isOpen;
        doorAnimator.SetBool("isOpen", isOpen);
    }
}
