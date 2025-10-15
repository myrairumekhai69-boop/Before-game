using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float damage = 25f;
    public float lifeTime = 5f;
    public LayerMask hitMask;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        var receiver = collision.collider.GetComponent<DamageReceiver>();
        if (receiver != null)
        {
            receiver.ApplyDamage(damage);
        }

        // optional impact VFX
        Destroy(gameObject);
    }
}
