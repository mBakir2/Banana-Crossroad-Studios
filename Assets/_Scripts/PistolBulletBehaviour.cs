using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBulletBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit the object: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
