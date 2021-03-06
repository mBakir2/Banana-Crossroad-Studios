using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 5th Apr 2020
 */
public class InstantiateArea : MonoBehaviour, IDropHandler
{
    public GameObject player;
    private Vector3 playerPosition;
    private Quaternion playerRotation;

    [Header("Prefabs to instantiate from inventory")]
    public GameObject firstAid;
    public GameObject ammo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        playerPosition = player.transform.position;
        playerRotation = player.transform.rotation;

        //Debug.Log("something dropped");
        //Debug.Log(eventData.pointerDrag);
        //Instantiate(firstAid, playerPosition + player.transform.forward * 10, playerRotation);

        if (eventData.pointerDrag.GetComponent<UIIdentifier>().identifier)
        {
            Instantiate(firstAid, playerPosition + player.transform.forward * 10, playerRotation);
            GameData.aidKits--;
        }
        else
        {
            Instantiate(ammo, playerPosition + player.transform.forward * 10, playerRotation);
            GameData.ammoPistol -= 60;
            GameData.ammoRifle -= 60;
        }
    }
}