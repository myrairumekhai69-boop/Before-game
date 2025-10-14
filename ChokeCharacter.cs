using UnityEngine;

public class ChokeCharacter : MonoBehaviour
{
    public string characterName = "Choke";
    public float health = 100f;
    public float speed = 4.5f;
    public SkinnedMeshRenderer faceRenderer;

    void Start()
    {
        Debug.Log(characterName + " is ready.");
        LoadFaceTexture();
    }

    void LoadFaceTexture()
    {
        // This would be the face texture linked to his skeleton
        Texture2D chokeFace = Resources.Load<Texture2D>("Textures/Faces/ChokeFace");
        if (chokeFace != null && faceRenderer != null)
        {
            faceRenderer.material.mainTexture = chokeFace;
            Debug.Log("Choke's face texture applied successfully.");
        }
        else
        {
            Debug.LogWarning("Choke face texture not found or faceRenderer not assigned!");
        }
    }

    void Update()
    {
        // Basic idle or walking test logic (for when we add movement later)
        transform.Rotate(Vector3.up * Time.deltaTime * 5f);
    }
}
