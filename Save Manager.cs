using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public float[] playerPosition;
    public float playerHealth;
    public string[] inventory;
    public int checkpointIndex;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public InventorySystem inventory;
    public DamageReceiver playerHealth;
    public Transform playerTransform;
    string saveFile => Path.Combine(Application.persistentDataPath, "save.json");

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }

    public void SaveGame(int checkpointIndex = 0)
    {
        SaveData d = new SaveData();
        d.playerPosition = new float[] { playerTransform.position.x, playerTransform.position.y, playerTransform.position.z };
        d.playerHealth = playerHealth != null ? playerHealth.health : 100f;
        d.inventory = inventory != null ? inventory.items.ToArray() : new string[0];
        d.checkpointIndex = checkpointIndex;

        string json = JsonUtility.ToJson(d, true);
        File.WriteAllText(saveFile, json);
        Debug.Log("Game saved to " + saveFile);
    }

    public bool LoadGame()
    {
        if (!File.Exists(saveFile)) return false;
        string json = File.ReadAllText(saveFile);
        SaveData d = JsonUtility.FromJson<SaveData>(json);
        if (playerTransform != null && d.playerPosition != null && d.playerPosition.Length == 3)
            playerTransform.position = new Vector3(d.playerPosition[0], d.playerPosition[1], d.playerPosition[2]);

        if (playerHealth != null) playerHealth.health = d.playerHealth;
        if (inventory != null) { inventory.items.Clear(); inventory.items.AddRange(d.inventory); }
        Debug.Log("Game loaded");
        return true;
    }
}
