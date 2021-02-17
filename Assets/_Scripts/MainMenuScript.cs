using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 14th Feb 2020
 */
public class MainMenuScript : MonoBehaviour
{
    public GameObject soundOnButt;
    public GameObject soundOffButt;
    public GameObject volumeSlider;

    public GameObject winText;
    public GameObject winSound;
    public GameObject loseText;
    public GameObject loseSound;
    // Start is called before the first frame update
    void Start()
    {
        if (GameData.sound == false)
        {
            soundOnButt.SetActive(false);
            volumeSlider.SetActive(false);
            soundOffButt.SetActive(true);
        }
        if (winText != null)
        {
            EndScreen();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        GameData.win = false;
        GameData.goals = 0;
    }
    public void QuitGame()
    {
        Debug.Log("The game has quit");
        //Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void EndScreen()
    {
        if (GameData.win)
        {
            winText.SetActive(true);
            winSound.SetActive(true);
            loseText.SetActive(false);
            loseSound.SetActive(false);
        }
    }
}
