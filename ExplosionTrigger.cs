using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    public GameObject explosionEffect;
    public AudioSource explosionSound;
    public CameraShake cameraShake;
    public bool triggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            TriggerExplosion();
        }
    }

    void TriggerExplosion()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        if (explosionSound != null)
            explosionSound.Play();

        if (cameraShake != null)
            StartCoroutine(cameraShake.Shake(1f, 0.3f));
    }
}
