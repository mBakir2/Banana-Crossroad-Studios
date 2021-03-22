using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

}
