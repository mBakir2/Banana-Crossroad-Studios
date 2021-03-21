using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (GameData.gunActive == 1)
        {
            bullet = new RifleBullet();
            bulletObject = Instantiate(rifleBulletPrefab);
            bullet.ShootBulletFromSpawnPoint(bulletObject, bulletSpawnPoint, transform);
            rifleGunshotAudioSource.Play();
            StartCoroutine(DestroyBulletAfterSpecifiedTime(bulletObject, bullet.lifetime));
            //bulletType.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bullet.speed, ForceMode.Impulse);
        } 
        else if (GameData.gunActive == 2)
        {
            bullet = new PistolBullet();
            bulletObject = Instantiate(pistolBulletPrefab);
            bullet.ShootBulletFromSpawnPoint(bulletObject, bulletSpawnPoint, transform);
            gunshotAudioSource.Play();
            StartCoroutine(DestroyBulletAfterSpecifiedTime(bulletObject, bullet.lifetime));
            //bulletType.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bullet.speed, ForceMode.Impulse);
        }


        //Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
        //    bulletSpawnPoint.parent.GetComponent<Collider>());

        //bulletObject.transform.position = bulletSpawnPoint.position;

        //Vector3 rotation = bullet.transform.rotation.eulerAngles;

        // add angle to 270 for rifle bullet rotation
        //bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y + 270, rotation.z);

        //bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

        // play gunshot sound

        // impulse to launch it with force once
        //bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);

        //StartCoroutine(DestroyBulletAfterSpecifiedTime(bullet, lifeTime));
    }

    private IEnumerator DestroyBulletAfterSpecifiedTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }
}
