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
 * Last Modified on: 16th Feb 2020
 */
public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject completion;
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

        if (GameData.goals == GameData.totalgoals)
        {
            GameData.win = true;
            SceneManager.LoadScene(2);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            completion.GetComponent<TMP_Text>().text = "Cures to Deliver " + GameData.goals + "/" + GameData.totalgoals;
        }
    }

    public void UnPauseGC()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
}
