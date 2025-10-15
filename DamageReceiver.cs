using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public float health = 100f;

    public void ApplyDamage(float amount)
    {
        health -= amount;
        if (health <= 0f) OnDeath();
    }

    protected virtual void OnDeath()
    {
        // default behaviour: disable object
        gameObject.SetActive(false);
    }
}
