using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 15th Apr 2020
 */
public static class GameData
{
    // stores the current values of all the keybindings and other options settings
    public static bool sound { get; set; } = true;
    public static bool win { get; set; } = false;
    public static int goals { get; set; } = 0;
    public static int totalgoals { get; set; } = 5;
    public static int playerHealth { get; set; } = 100;
    public static bool hasRifle { get; set; } = false;
    public static bool hasPistol { get; set; } = false;
    public static int ammoRifle { get; set; } = 0;
    public static int ammoPistol { get; set; } = 0;

    // 0 = No Gun, 1 = Rifle, 2 = Pistol
    public static int gunActive { get; set; } = 0;
    public static int aidKits { get; set; } = 0;

    public static bool loadFromMainMenu { get; set; } = false;
    public static bool loadTutorial { get; set; } = false;
    public static KeyCode forwardKey { get; set; } = KeyCode.W;
    public static KeyCode leftKey { get; set; } = KeyCode.A;
    public static KeyCode backKey { get; set; } = KeyCode.S;
    public static KeyCode rightKey { get; set; } = KeyCode.D;
    public static KeyCode jumpKey { get; set; } = KeyCode.Space;

    public static GameObject objectSelected;

    // achievements
    public static bool winOnce = false;
    public static bool loseOnce = false;
    public static bool cureOnce = false;
    public static bool killOnce = false;
    public static bool winWithoutGun = false;
}
