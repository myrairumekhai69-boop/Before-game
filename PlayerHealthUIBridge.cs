using UnityEngine;

[RequireComponent(typeof(DamageReceiver))]
public class PlayerHealthUIBridge : MonoBehaviour
{
    public HUDController hud;
    public float maxHealth = 100f;
    DamageReceiver receiver;

    void Awake() { receiver = GetComponent<DamageReceiver>(); }

    void Start()
    {
        if (hud) hud.SetHealth(receiver.health, maxHealth);
    }

    public void OnDamageTaken()
    {
        if (hud) hud.SetHealth(receiver.health, maxHealth);
    }
}
