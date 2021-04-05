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
    public GameObject firstaidDropUI;
    public GameObject ammoDropUI;
    private int firstAidDroppable;
    private int ammoDroppable = 1;
    private int ammoCombined;
    private Slots[] boxes;
    // Start is called before the first frame update
    void Start()
    {
        firstAidDroppable = GameData.aidKits;
        boxes = FindObjectsOfType<Slots>();

        if (GameData.ammoPistol / 60 > GameData.ammoRifle / 60)
        {
            ammoCombined = GameData.ammoRifle / 60;
        }
        else
        {
            ammoCombined = GameData.ammoRifle / 60;
        }
        Debug.Log(firstAidDroppable);
        Debug.Log(GameData.aidKits);
        Debug.Log(ammoCombined);
        Debug.Log(ammoDroppable);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (firstAidDroppable > GameData.aidKits)
        {
            //remove firstaid prefab on inventory

            while (firstAidDroppable != GameData.aidKits)
            {
                foreach (Slots slot in boxes)
                {
                    if (slot.isTaken)
                    {
                        if (!slot.GetComponentInChildren<UIIdentifier>().identifier)
                        {
                            Destroy(slot.GetComponentInChildren<UIIdentifier>().gameObject);
                            //destroy child of slot not slot
                            firstAidDroppable--;
                            break;
                        }
                    }
                }
            }

        }
        else if ( firstAidDroppable < GameData.aidKits)
        {
            //add a firstaid prefab on inventory

            while (firstAidDroppable != GameData.aidKits)
            {
                foreach (Slots slot in boxes)
                {
                    if (!slot.isTaken)
                    {
                        Instantiate(firstaidDropUI, slot.gameObject.transform);
                        firstAidDroppable++;
                        break;
                    }
                }
            }
        }

        //counts the ammo boxes droppable with a 60 rifle ammo and 60 pistol ammo
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
            while (ammoDroppable != ammoCombined)
            {
                for (int i = 0; i < boxes.Length; i++)
                {
                    if (boxes[i].isTaken)
                    {
                        if (!boxes[i].GetComponent<UIIdentifier>().identifier)
                        {
                            Destroy(boxes[i].GetComponentInChildren<UIIdentifier>().gameObject);
                            //destroy child of slot not slot
                            ammoDroppable--;
                            break;
                        }
                    }
                }
            }
        }
        else if (ammoDroppable < ammoCombined)
        {
            //add an ammo prefab on inventory

            while (ammoDroppable != GameData.aidKits)
            {
                for (int i = 0; i < boxes.Length; i++)
                {
                    if (boxes[i].isTaken)
                    {
                        Instantiate(ammoDropUI, boxes[i].gameObject.transform);
                        ammoDroppable++;
                        break;
                    }
                }
            }
        }
    }
}
