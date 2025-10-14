using UnityEngine;

/// <summary>
/// Tami Darby - 5 year old child character skeleton for Before Us.
/// This MonoBehaviour expects a 3D skinned mesh with a SkinnedMeshRenderer and an Animator.
/// It will try to load a face texture from Resources/Textures/Faces/TamiFace (PNG).
/// </summary>
public class TamiCharacter : MonoBehaviour
{
    [Header("Identity")]
    public string characterName = "Tami Darby";
    public int age = 5;

    [Header("Stats")]
    public float health = 70f;
    public float speed = 3.0f;

    [Header("References (assign in Inspector or automatically)")]
    public SkinnedMeshRenderer faceRenderer;    // skinned mesh renderer for head/face
    public Animator animator;                   // animator for humanoid animations
    public AudioSource voiceSource;             // optional audio source for voice lines

    [Header("Defaults")]
    public string faceResourcePath = "Textures/Faces/TamiFace"; // Resources path (no extension)

    void Awake()
    {
        // Try to auto-assign common components if not set
        if (faceRenderer == null)
        {
            faceRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (voiceSource == null)
        {
            voiceSource = GetComponent<AudioSource>();
        }
    }

    void Start()
    {
        Debug.Log($"{characterName} (age {age}) ready.");
        ApplyFaceFromResources();
        SetupIdlePose();
    }

    /// <summary>
    /// Loads a texture named Assets/Resources/Textures/Faces/TamiFace.png
    /// and applies it to the faceRenderer's material main texture.
    /// </summary>
    public void ApplyFaceFromResources()
    {
        if (faceRenderer == null)
        {
            Debug.LogWarning("TamiCharacter: faceRenderer not assigned. Cannot apply face texture.");
            return;
        }

        Texture2D faceTex = Resources.Load<Texture2D>(faceResourcePath);
        if (faceTex != null)
        {
            // Make a new material instance to avoid overwriting shared material at runtime
            Material inst = new Material(faceRenderer.sharedMaterial);
            inst.mainTexture = faceTex;
            faceRenderer.material = inst;
            Debug.Log("Tami's face texture applied from Resources.");
        }
        else
        {
            Debug.LogWarning($"TamiCharacter: No texture found at Resources/{faceResourcePath}.png");
        }
    }

    void SetupIdlePose()
    {
        if (animator != null)
        {
            // Ensure animator is in a known state (requires an Animator Controller with "Idle" state)
            animator.Play("Idle", 0, 0f);
        }
    }

    void Update()
    {
        // Lightweight rotation so you can visually inspect the model in a scene view/test
        transform.Rotate(Vector3.up * Time.deltaTime * 10f, Space.World);
    }

    // Example gameplay methods
    public void Speak(AudioClip clip)
    {
        if (voiceSource != null && clip != null)
        {
            voiceSource.clip = clip;
            voiceSource.Play();
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            health = 0f;
            Debug.Log($"{characterName} is down!");
            if (animator != null) animator.SetTrigger("Fall");
        }
        else
        {
            Debug.Log($"{characterName} takes {amount} damage. Health: {health}");
            if (animator != null) animator.SetTrigger("Hurt");
        }
    }
}
