using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    public Transform[] checkpoints;
    int currentIndex = 0;

    public void SetCheckpoint(int index)
    {
        currentIndex = Mathf.Clamp(index, 0, checkpoints.Length - 1);
        PlayerPrefs.SetInt("checkpointIndex", currentIndex);
    }

    public int GetCheckpointIndex()
    {
        return PlayerPrefs.GetInt("checkpointIndex", 0);
    }

    public Vector3 GetCheckpointPosition()
    {
        int i = GetCheckpointIndex();
        if (checkpoints != null && i >= 0 && i < checkpoints.Length)
            return checkpoints[i].position;
        return Vector3.zero;
    }
}
