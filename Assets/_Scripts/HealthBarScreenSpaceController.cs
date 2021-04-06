using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 21st March 2020
 */

[System.Serializable]
public class HealthBarScreenSpaceController : MonoBehaviour
{
    [Range(0, 100)]
    public int currentHealth = 100;
    [Range(1, 100)]
    public int maximumHealth = 100;

    public Slider healthBarSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthBarSlider = GetComponent<Slider>();
        currentHealth = maximumHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    public void TakeDamage(int damage)
    {
        healthBarSlider.value -= damage;
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
            healthBarSlider.value = 0;
        }
    }
    public void SetHealth(int health)
    {
        healthBarSlider.value = health;
        currentHealth = health;
    }
    public void Reset()
    {
        currentHealth = maximumHealth;
        healthBarSlider.value = maximumHealth;
    }
}
