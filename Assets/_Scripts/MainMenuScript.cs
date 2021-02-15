using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject soundOnButt;
    public GameObject soundOffButt;
    public GameObject volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (GameData.sound == false)
        {
            soundOnButt.SetActive(false);
            volumeSlider.SetActive(false);
            soundOffButt.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
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
}
