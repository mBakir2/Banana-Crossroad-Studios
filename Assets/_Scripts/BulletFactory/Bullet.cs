using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 21st March 2020
 */
public abstract class Bullet
{
    public float speed { get; set; }

    public float lifetime { get; set; }

    public abstract void ShootBulletFromSpawnPoint(GameObject bullet, Transform bulletSpawn, Transform playerTransform);

}
