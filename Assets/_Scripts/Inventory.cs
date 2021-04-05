using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 4th Apr 2020
 */
public class Inventory : MonoBehaviour
{
    private int firstAidDroppable;
    private int ammoDroppable;
    private int ammoCombined;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (firstAidDroppable > GameData.aidKits)
        {
            //remove firstaid prefab on inventory


        }
        else if ( firstAidDroppable < GameData.aidKits)
        {
            //add a firstaid prefab on inventory
        }

        if (GameData.ammoPistol / 60 > GameData.ammoRifle / 60)
        {
            ammoCombined = GameData.ammoRifle / 60;
        }
        else
        {
            ammoCombined = GameData.ammoRifle / 60;
        }
        

        if (ammoDroppable > ammoCombined)
        {
            //remove an ammo prefab on inventory
        }
        else if (ammoDroppable < ammoCombined)
        {
            //add an ammo prefab on inventory
        }
    }
}
