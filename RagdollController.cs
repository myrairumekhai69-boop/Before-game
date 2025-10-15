using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Rigidbody[] ragdollBodies;
    public Collider[] ragdollColliders;
    public Animator animator;

    void Awake()
    {
        SetRagdoll(false);
    }

    public void SetRagdoll(bool enabled)
    {
        if (animator) animator.enabled = !enabled;
        foreach (var rb in ragdollBodies)
            rb.isKinematic = !enabled;
        foreach (var col in ragdollColliders)
            col.enabled = enabled;
    }

    public void ActivateRagdoll()
    {
        SetRagdoll(true);
    }
}
