using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : BaseEnemy
{
    // Inspector Fields
    [SerializeField] private float fireInterval = 2f;
    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {
        StartCoroutine(ShootBulletRoutine());
    }

    IEnumerator ShootBulletRoutine()
    {
        while(true)
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.GetComponent<Projectile>().InitBullet(Vector2.right);
            Destroy(newBullet, 3f);
            yield return new WaitForSeconds(fireInterval);
            yield return null;
        }
    }
}
