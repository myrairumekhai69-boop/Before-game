using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [Header("Gun")]
    public Transform muzzle;
    public GameObject bulletPrefab;
    public float bulletSpeed = 40f;
    public float fireRate = 1f;
    public float burstDelay = 0.1f;

    float nextFire = 0f;
    Transform player;

    void Awake()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        if (p) player = p.transform;
    }

    void Update()
    {
        if (player == null) return;
        if (Time.time < nextFire) return;

        Vector3 dir = (player.position + Vector3.up*1.2f - muzzle.position).normalized;
        Shoot(dir);
        nextFire = Time.time + 1f / fireRate;
    }

    void Shoot(Vector3 dir)
    {
        if (bulletPrefab == null || muzzle == null) return;
        GameObject b = Instantiate(bulletPrefab, muzzle.position, Quaternion.LookRotation(dir));
        var rb = b.GetComponent<Rigidbody>();
        if (rb) rb.velocity = dir * bulletSpeed;
    }
}
