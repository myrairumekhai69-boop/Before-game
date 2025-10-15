using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public GameObject deathPrefab;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(float amount, Vector3 hitPoint, Vector3 hitForce)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f) Die();
    }

    void Die()
    {
        // optional ragdoll or effect
        if (deathPrefab) Instantiate(deathPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}
