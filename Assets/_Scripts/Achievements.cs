using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public GameObject cured;
    public GameObject killed;
    public GameObject won;
    public GameObject lost;
    public GameObject superwin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.cureOnce)
        {
            cured.SetActive(true);
        }

        if (GameData.killOnce)
        {
            killed.SetActive(true);
        }

        if (GameData.winOnce)
        {
            won.SetActive(true);
        }

        if (GameData.loseOnce)
        {
            lost.SetActive(true);
        }

        if (GameData.winWithoutGun)
        {
            superwin.SetActive(true);
        }
    }
}
