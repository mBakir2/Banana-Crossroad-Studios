using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 8th Mar 2020
 */
public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject completion;
    public GameObject uiRifle;
    public GameObject uiRifleActive;
    public GameObject uiPistol;
    public GameObject uiPistolActive;
    public GameObject uiRifAmmo;
    public GameObject uiPisAmmo;
    public GameObject ammo;
    public GameObject uiAid;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //pauses game
        if (Input.GetButton("Cancel"))
        {
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }

        // displays the win screen if the player has completed all the goals
        if (GameData.goals == GameData.totalgoals)
        {
            GameData.win = true;
            SceneManager.LoadScene(2);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // updates the game UI if the player has completed a goal
            completion.GetComponent<TMP_Text>().text = "Cures to Deliver " + GameData.goals + "/" + GameData.totalgoals;
        }

        //updates user ui -  items
        if (GameData.hasRifle)
        {
            uiRifle.SetActive(true);
        }
        if (GameData.hasPistol)
        {
            uiPistol.SetActive(true);
        }

        if (GameData.gunActive == 1)
        {
            uiRifleActive.SetActive(true);
            uiPistolActive.SetActive(false);
            ammo.GetComponent<TMP_Text>().text = GameData.ammoRifle.ToString();
            uiRifAmmo.SetActive(true);
            uiPisAmmo.SetActive(false);
        }
        else if (GameData.gunActive == 2)
        {
            uiRifleActive.SetActive(false);
            uiPistolActive.SetActive(true);
            ammo.GetComponent<TMP_Text>().text = GameData.ammoPistol.ToString();
            uiRifAmmo.SetActive(false);
            uiPisAmmo.SetActive(true);
        }

        uiAid.GetComponent<TMP_Text>().text = GameData.aidKits.ToString();

    }

    // resume the game
    public void UnPauseGC()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
}
