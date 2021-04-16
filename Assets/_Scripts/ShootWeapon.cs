using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 21th Mar 2020
 */
public class ShootWeapon : MonoBehaviour
{
    [Header("Bullet Properties")]
    public GameObject pistolBulletPrefab;
    public GameObject rifleBulletPrefab;

    public Transform bulletSpawnPoint;

    public float lifeTime = 3;

    public float bulletSpeed = 30;

    [Header("GunShot Sounds")]
    public AudioSource gunshotAudioSource;

    public AudioSource rifleGunshotAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shootWeapon()
    {
        Bullet bullet;
        GameObject bulletObject;

        if (GameData.gunActive == 1 && GameData.ammoRifle > 0)
        {
            bullet = new RifleBullet();
            bulletObject = Instantiate(rifleBulletPrefab);
            rifleGunshotAudioSource.Play();
            bullet.ShootBulletFromSpawnPoint(bulletObject, bulletSpawnPoint, transform);
            StartCoroutine(DestroyBulletAfterSpecifiedTime(bulletObject, bullet.lifetime));
            GameData.ammoRifle--;
        } 
        else if (GameData.gunActive == 2 && GameData.ammoPistol > 0)
        {
            bullet = new PistolBullet();
            bulletObject = Instantiate(pistolBulletPrefab);
            gunshotAudioSource.Play();
            bullet.ShootBulletFromSpawnPoint(bulletObject, bulletSpawnPoint, transform);
            StartCoroutine(DestroyBulletAfterSpecifiedTime(bulletObject, bullet.lifetime));
            GameData.ammoPistol--;
        }
    }

    private IEnumerator DestroyBulletAfterSpecifiedTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }
}
