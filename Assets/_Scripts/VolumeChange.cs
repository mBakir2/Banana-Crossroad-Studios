using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 14th Feb 2020
 */
public class VolumeChange : MonoBehaviour
{
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevel(float level)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(level) * 20);
    }

    public void LevelOff()
    {
        mixer.SetFloat("MasterVol", -80f);
        GameData.sound = false;
    }

    public void LevelOn()
    {
        mixer.SetFloat("MasterVol", -6f);
        GameData.sound = true;
    }
}
