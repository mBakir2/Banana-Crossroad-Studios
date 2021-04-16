using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject leftJoystickMove;
    public GameObject rightJoystickMove;
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

    private Quaternion initialJoyStickRotation = new Quaternion(0, 0, 0, 0);
    private Vector3 initialplayerPosition = new Vector3(0, 0, 0);

    private bool rightJoystickPopupShown = false;
    private bool leftJoystickPopupShown = true;
    private bool jumpButtonPopupShown = true;
    private bool achivementsButtonPopupShown = true;

    // Start is called before the first frame update
    void Start()
    {
        initialJoyStickRotation = rightJoystickMove.transform.localRotation;
        initialplayerPosition = leftJoystickMove.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rightJoystickPopupShown)
        {
            ActivateRightJoystickPopup();
        }

        if (!leftJoystickPopupShown)
        {
            ActivateLeftJoystickPopup();
        }

        if (!jumpButtonPopupShown)
        {
            ActivateJumpPopup();
        }

        if (!achivementsButtonPopupShown)
        {
            ActivateAchievementPopup();
        }
    }

    private void ActivateRightJoystickPopup()
    {
        rightJoystickPopups.gameObject.SetActive(true);
        if (initialJoyStickRotation != rightJoystickMove.transform.localRotation)
        {
            rightJoystickPopups.gameObject.SetActive(false);
            initialJoyStickRotation = new Quaternion(0, 0, 0, 0);
            rightJoystickPopupShown = true;
            leftJoystickPopupShown = false;
        }
    }

    private void ActivateLeftJoystickPopup()
    {
        leftJoystickPopups.gameObject.SetActive(true);
        if (initialplayerPosition.x != leftJoystickMove.transform.localPosition.x || initialplayerPosition.z != leftJoystickMove.transform.localPosition.z)
        {
            leftJoystickPopups.gameObject.SetActive(false);
            initialplayerPosition = new Vector3(0, 0, 0);
            leftJoystickPopupShown = true;
            jumpButtonPopupShown = false;
        }
    }

    private void ActivateJumpPopup()
    {
        bool jumpNotClickedOnce = true;
        jumpPopup.gameObject.SetActive(true);
        jumpButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (jumpNotClickedOnce)
            {
                jumpPopup.gameObject.SetActive(false);
                jumpNotClickedOnce = false;
                jumpButtonPopupShown = true;
                achivementsButtonPopupShown = false;
            }
        });
    }

    private void ActivateAchievementPopup()
    {
        bool achievementNotClickedOnce = true;
        achivementsPopup.gameObject.SetActive(true);
        achivementsButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (achievementNotClickedOnce)
            {
                achivementsPopup.gameObject.SetActive(false);
                achievementNotClickedOnce = false;
                achivementsButtonPopupShown = true;
            }
        });
    }

}
