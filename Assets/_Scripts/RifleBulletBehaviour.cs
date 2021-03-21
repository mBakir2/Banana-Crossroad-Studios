using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleBulletBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit the object: " + other.gameObject.name);
            StartCoroutine(DestroyBulletAfterSpecifiedTime(gameObject, 2));
            other.gameObject.GetComponent<DarkSeekerBehaviour>().TakeDamage(10);
        }
    }

    private IEnumerator DestroyBulletAfterSpecifiedTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(bullet);
    }
}
