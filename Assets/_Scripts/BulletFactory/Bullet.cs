using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet
{
    public float speed { get; set; }

    public float lifetime { get; set; }

    public abstract void ShootBulletFromSpawnPoint(GameObject bullet, Transform bulletSpawn, Transform playerTransform);

}
