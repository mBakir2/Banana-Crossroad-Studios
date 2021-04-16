using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [Header("Buttons")]
    public Joystick leftJoystick;
    public Joystick rightJoystick;
    public GameObject shootButton;
    public GameObject jumpButton;
    public GameObject inventoryButton;
    public GameObject pauseButton;
    public GameObject achivementsButton;
    public GameObject PauseMenuReturnButton;

    [Header("Tutorial Popups")]
    public GameObject jumpPopup;
    public GameObject shootPopup;
    public GameObject rightJoystickPopups;
    public GameObject leftJoystickPopups;
    public GameObject achivementsPopup;
    public GameObject InventoryPopup;
    public GameObject pauseButtonPopup;
    public GameObject sideInventoryPopup;

    // Start is called before the first frame update
    void Start()
    {
        if (GameData.loadTutorial)
        {
            Debug.Log("Loading the tutorial");
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (GameData.loadTutorial)
       {
            
       }
    }
}
