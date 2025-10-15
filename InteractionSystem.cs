using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public float interactRange = 3f;
    public LayerMask interactableLayer;
    public Camera playerCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactableLayer))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                    interactable.OnInteract();
            }
        }
    }
}
