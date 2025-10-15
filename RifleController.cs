using UnityEngine;
using System.Collections;

public class RifleController : MonoBehaviour
{
    [Header("Rifle")]
    public Transform muzzle;
    public GameObject bulletPrefab;
    public float fireRate = 6f; // rounds per second
    public int magazineSize = 30;
    public float reloadTime = 2.1f;
    public float recoilAmount = 0.02f;

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

        if (Input.GetButton("Fire1") && Time.time >= nextFire)
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
            if (rb) rb.velocity = muzzle.forward * 60f;
        }

        // simple recoil effect
        transform.localPosition -= transform.forward * recoilAmount;
    }

    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magazineSize;
        reloading = false;
    }
}
