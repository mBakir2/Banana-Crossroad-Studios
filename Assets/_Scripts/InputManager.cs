using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Dictionary<string, KeyCode> buttonPresses;
    // Start is called before the first frame update
    void Start()
    {
        buttonPresses = new Dictionary<string, KeyCode>();

        buttonPresses["Jump"] = KeyCode.Space;
        buttonPresses["Left"] = KeyCode.LeftArrow;
        buttonPresses["Right"] = KeyCode.RightArrow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetButtonDown(string btnName)
    {
        if (buttonPresses.ContainsKey(btnName) == false)
        {
            Debug.LogError("No Button named the specified button");
        }

        return Input.GetKeyDown(buttonPresses[btnName]);
    }
}
