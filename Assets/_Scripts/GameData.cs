using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 16th Feb 2020
 */
public static class GameData
{
    public static bool sound { get; set; } = true;
    public static bool win { get; set; } = false;
    public static int goals { get; set; } = 0;
    public static KeyCode forwardKey { get; set; } = KeyCode.W;
    public static KeyCode leftKey { get; set; } = KeyCode.A;
    public static KeyCode backKey { get; set; } = KeyCode.S;
    public static KeyCode rightKey { get; set; } = KeyCode.D;
    public static KeyCode jumpKey { get; set; } = KeyCode.Space;
}
