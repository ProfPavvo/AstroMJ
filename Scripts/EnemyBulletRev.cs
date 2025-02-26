using UnityEngine;

public class EnemyBulletRev : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab to spawn
    public Transform firePoint; // The point from where the bullet will be fired
    public float bulletSpeed = 5f;
    public float fireRate = 2f; // Fire a bullet every 2 seconds

    private void Start()
    {
        InvokeRepeating("FireBulletR", 0f, fireRate);
    }

    private void FireBulletR()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.right * bulletSpeed; // Fire towards the left
        }
    }
}
