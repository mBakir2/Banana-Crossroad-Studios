using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 16th Feb 2020
 */

public class attachPlayerToPlatform : MonoBehaviour
{
    // getting reference to player object
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // called when other body enters the trigger area of the platform
    private void OnTriggerEnter(Collider other)
    {
        // attaches the parent of the player transform to the platform's transform
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
            Player.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // called when other body exits the trigger area of the platform
    private void OnTriggerExit(Collider other)
    {
        // attaches the parent of the player transform to the platform's transform
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
