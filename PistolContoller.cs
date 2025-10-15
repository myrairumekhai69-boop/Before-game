using UnityEngine;
using System.Collections;

public class PistolController : MonoBehaviour
{
    public Transform muzzle;
    public GameObject bulletPrefab;
    public float fireRate = 3f;
    public int magazineSize = 12;
    public float reloadTime = 1.2f;

    int currentAmmo;
    bool reloading = false;
    float nextFire = 0f;

    void Start()
    {
        currentAmmo = magazineSize;
    }

    void Update()
    {
        if (reloading) return;

        if (Input.GetButtonDown("Fire1") && Time.time >= nextFire)
        {
            if (currentAmmo > 0) Fire();
            else StartCoroutine(Reload());
        }

        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(Reload());
    }

    void Fire()
    {
        nextFire = Time.time + 1f / fireRate;
        currentAmmo--;

        if (bulletPrefab && muzzle)
        {
            GameObject b = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            var rb = b.GetComponent<Rigidbody>();
            if (rb) rb.velocity = muzzle.forward * 70f;
        }
    }

    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magazineSize;
        reloading = false;
    }
}
