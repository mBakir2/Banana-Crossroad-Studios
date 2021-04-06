using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 29th March 2020
 */

[CreateAssetMenu(fileName = "SceneData", menuName = "Data/SceneData")]
public class SceneDataSO : ScriptableObject
{
    // Player Data
    [Header("Player Data")]
    public Vector3 playerPosition;
    public Quaternion playerRotation;
    public int playerHealth;
    public int cures;
    public bool hasPistol;
    public bool hasRifle;
    public int gunActive;

    // Enemy Data
    [Header("Enemy Data")]
    public Vector3[] darkSeekersPosition;
    public Quaternion[] enemyRotation;
    public int[] enemyHealth;

    //Pickups Goal Data
    public Vector3[] riflePickup;
    public Vector3[] pistolPickup;
    public Vector3[] goalsPickup;
    public Vector3[] firstAidsPickup;
    public Vector3[] ammoPickup;

    public DarkSeekerSaveData darkSeekersSaveData;

}
