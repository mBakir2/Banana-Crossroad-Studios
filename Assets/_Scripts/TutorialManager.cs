using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 16th Apr 2020
 */

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
    public GameObject achivementsOpenPopup;
    public GameObject inventoryPopup;
    public GameObject pauseButtonPopup;
    public GameObject sideInventoryPopup;
    public GameObject returnToMainmenuPopup;

    private Quaternion initialJoyStickRotation = new Quaternion(0, 0, 0, 0);
    private Vector3 initialplayerPosition = new Vector3(0, 0, 0);

    // popup shown booleans for sequencing
    private bool rightJoystickPopupShown = false;
    private bool leftJoystickPopupShown = true;
    private bool jumpButtonPopupShown = true;
    private bool achivementsButtonPopupShown = true;
    private bool achivementsOpenButtonPopupShown = true;
    private bool inventoryButtonPopupShown = true;
    private bool pauseButtonPopupShown = true;
    private bool sideInventoryPopupShown = true;
    private bool shootButtonPopupShown = true;
    private bool returnToMainMenuPopupShown = true;

    // Start is called before the first frame update
    void Start()
    {
        // setting up intial rotation of camera and position of player
        initialJoyStickRotation = rightJoystickMove.transform.localRotation;
        initialplayerPosition = leftJoystickMove.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // sequencing the popups according to their boolean values
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

        if (!achivementsOpenButtonPopupShown)
        {
            ActivateAchievementOpenPopup();
        }

        if (!inventoryButtonPopupShown)
        {
            ActivateInventoryPopup();
        }

        if (!pauseButtonPopupShown)
        {
            ActivatePauseButtonPopup();
        }

        if (!shootButtonPopupShown)
        {
            ActivateShootButtonPopup();
        }

        if (!sideInventoryPopupShown)
        {
            ActivateSideInventoryPopup();
        }

        if (!returnToMainMenuPopupShown)
        {
            returnToMainmenuPopup.gameObject.SetActive(true);
        }
    }

    /** 
     * Activate popups and deactivate them after user interacts with the buttons or joysticks
     * */
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
                achivementsOpenButtonPopupShown = false;
            }
        });
    }

    private void ActivateAchievementOpenPopup()
    {
        bool achievementOpenNotClickedOnce = true;
        achivementsOpenPopup.gameObject.SetActive(true);
        achivementsButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (achievementOpenNotClickedOnce)
            {
                achivementsOpenPopup.gameObject.SetActive(false);
                achievementOpenNotClickedOnce = false;
                achivementsOpenButtonPopupShown = true;
                inventoryButtonPopupShown = false;
            }
        });
    }

    private void ActivateInventoryPopup()
    {
        bool inventoryNotClickedOnce = true;
        inventoryPopup.gameObject.SetActive(true);
        inventoryButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (inventoryNotClickedOnce)
            {
                inventoryPopup.gameObject.SetActive(false);
                inventoryNotClickedOnce = false;
                inventoryButtonPopupShown = true;
                listenForInventoryButtonClose();
            }
        });
    }

    // on click listener for inventory button to open the next popup
    private void listenForInventoryButtonClose()
    {
        bool inventoryNotClickedOnce = true;
        inventoryButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (inventoryNotClickedOnce)
            {
                pauseButtonPopupShown = false;
                inventoryNotClickedOnce = false;
            }
        });
    }

    private void ActivatePauseButtonPopup()
    {
        bool pauseNotClickedOnce = true;
        pauseButtonPopup.gameObject.SetActive(true);
        pauseButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (pauseNotClickedOnce)
            {
                pauseButtonPopup.gameObject.SetActive(false);
                pauseNotClickedOnce = false;
                pauseButtonPopupShown = true;
                listenForPauseButtonClose();
            }
        });
    }

    // on click listener for pause button to open the next popup
    private void listenForPauseButtonClose()
    {
        bool pauseButtonNotClickedOnce = true;
        PauseMenuReturnButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (pauseButtonNotClickedOnce)
            {
                shootButtonPopupShown = false;
                pauseButtonNotClickedOnce = false;
            }
        });
    }

    private void ActivateShootButtonPopup()
    {
        bool shootButtonNotClickedOnce = true;
        shootPopup.gameObject.SetActive(true);
        shootButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (shootButtonNotClickedOnce)
            {
                shootPopup.gameObject.SetActive(false);
                shootButtonNotClickedOnce = false;
                shootButtonPopupShown = true;
                sideInventoryPopupShown = false;
            }
        });
    }

    private void ActivateSideInventoryPopup()
    {
        sideInventoryPopup.gameObject.SetActive(true);
        StartCoroutine(DeactivateSideInventoryPopup(5.0f));
    }

    // Couroutine for disabling the last popup and showing the end tutorial screen
    private IEnumerator DeactivateSideInventoryPopup(float delay)
    {
        yield return new WaitForSeconds(delay);

        sideInventoryPopup.gameObject.SetActive(false);
        sideInventoryPopupShown = true;
        returnToMainMenuPopupShown = false;
    }

}
