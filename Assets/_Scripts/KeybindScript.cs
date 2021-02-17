using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 16th Feb 2020
 */
public class KeybindScript : MonoBehaviour
{
    public Button wButt;
    public Button aButt;
    public Button sButt;
    public Button dButt;
    public Button jumpButt;
    public GameObject pressCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!wButt.enabled && Input.anyKeyDown)
        {
            pressCanvas.SetActive(false);
            foreach (KeyCode wKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(wKey))
                {
                    GameData.forwardKey = wKey;
                }
            }
            wButt.enabled = true;
        }

        if (!aButt.enabled && Input.anyKeyDown)
        {
            pressCanvas.SetActive(false);
            foreach (KeyCode aKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(aKey))
                {
                    GameData.leftKey = aKey;
                }
            }
            aButt.enabled = true;
        }

        if (!sButt.enabled && Input.anyKeyDown)
        {
            pressCanvas.SetActive(false);
            foreach (KeyCode sKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(sKey))
                {
                    GameData.backKey = sKey;
                }
            }
            sButt.enabled = true;
        }

        if (!dButt.enabled && Input.anyKeyDown)
        {
            pressCanvas.SetActive(false);
            foreach (KeyCode dKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(dKey))
                {
                    GameData.rightKey = dKey;
                }
            }
            dButt.enabled = true;
        }

        if (!jumpButt.enabled && Input.anyKeyDown)
        {
            pressCanvas.SetActive(false);
            foreach (KeyCode jKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(jKey))
                {
                    GameData.jumpKey = jKey;
                }
            }
            jumpButt.enabled = true;
        }

    }
}
