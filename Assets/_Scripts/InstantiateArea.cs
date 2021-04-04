using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 4th Apr 2020
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
        if (eventData.pointerDrag != null)
        {
            Instantiate(firstAid, playerPosition + new Vector3(10, 0), playerRotation);
        }
    }
}