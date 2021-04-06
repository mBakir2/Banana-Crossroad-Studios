using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 5th Apr 2020
 */
public class PickupRifle : MonoBehaviour
{
    public GameObject rifle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameData.hasRifle = true;
            GameData.ammoRifle += 60;
            if (GameData.gunActive == 0)
            {
                GameData.gunActive = 1;
                rifle.SetActive(true);
            }
        }
    }
}
