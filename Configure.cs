using UnityEngine;

public static class Config
{
    // Tags
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";
    public const string INTERACTABLE_TAG = "Interactable";

    // Layers
    public const string GROUND_LAYER = "Ground";

    // Player stats
    public static float playerMaxHealth = 100f;
    public static float walkSpeed = 3f;
    public static float runSpeed = 6f;

    // Keys
    public static KeyCode pauseKey = KeyCode.Escape;
}
