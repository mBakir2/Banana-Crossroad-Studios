using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public void UnPauseGC()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
}
