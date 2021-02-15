using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 14th Feb 2020
 */
public static class GameData
{
    public static bool sound { get; set; } = true;
    public static bool win { get; set; } = true;
    public static KeyCode wKey { get; set; } = KeyCode.W;
    public static KeyCode aKey { get; set; } = KeyCode.A;
    public static KeyCode sKey { get; set; } = KeyCode.S;
    public static KeyCode dKey { get; set; } = KeyCode.D;
    public static KeyCode jumpKey { get; set; } = KeyCode.Space;
}
