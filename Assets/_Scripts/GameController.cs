using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 9th Mar 2020
 */
public class GameController : MonoBehaviour
{
    public int numOfDarkSeekers = 6;
    public GameObject pauseMenu;
    public GameObject inventory;
    public GameObject completion;
    public GameObject uiRifle;
    public GameObject uiRifleActive;
    public GameObject uiPistol;
    public GameObject uiPistolActive;
    public GameObject uiRifAmmo;
    public GameObject uiPisAmmo;
    public GameObject ammo;
    public GameObject uiAid;
    public GameObject rifle;
    public GameObject pistol;

    [Header("Player Settings")]
    public PlayerBehaviour player;
    public CameraController playerCamera;

    [Header("Dark Seeker Settings")]
    public DarkSeekerBehaviour[] darkseekers;

    [Header("Scene Data")]
    public SceneDataSO sceneData;


    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<PlayerBehaviour>();
        darkseekers = FindObjectsOfType<DarkSeekerBehaviour>();
        playerCamera = FindObjectOfType<CameraController>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //pauses game
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    pauseGame();
        //    Cursor.lockState = CursorLockMode.None;
        //    Time.timeScale = 0f;
        //}

        // displays the win screen if the player has completed all the goals
        if (GameData.goals == GameData.totalgoals)
        {
            GameData.win = true;
            SceneManager.LoadScene(2);
            //Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // updates the game UI if the player has completed a goal
            completion.GetComponent<TMP_Text>().text = "Cures to Deliver " + GameData.goals + "/" + GameData.totalgoals;
        }

        //inventory
        if (Input.GetKeyDown(KeyCode.I) && !inventory.activeSelf)
        {
            inventory.SetActive(true);
            //Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(false);
            //Cursor.lockState = CursorLockMode.Locked;
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
        //Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    // saves the game by making a save.json file
    public void SaveGame()
    {
        // getting the player, enemies game objects
        PlayerBehaviour playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        DarkSeekerObject[] darkseekersSaveArray = new DarkSeekerObject[numOfDarkSeekers];

        for(int i = 0; i < darkseekers.Length; i++)
        {
            darkseekersSaveArray[i] = new DarkSeekerObject
            {
                name = darkseekers[i].gameObject.name,
                position = darkseekers[i].transform.position
            };
            Debug.Log(darkseekers[i].gameObject.name);
            Debug.Log(darkseekers[i].transform.position);
        }

        // making the save object with all the data
        SaveObject saveObj = new SaveObject {
            playerPosition = playerBehaviour.transform.position,
            playerHealth = GameData.playerHealth,
            enemies = darkseekersSaveArray,
            win = GameData.win,
            goals = GameData.goals,
            hasRifle = GameData.hasRifle,
            hasPistol = GameData.hasPistol,
            ammoRifle = GameData.ammoRifle,
            ammoPistol = GameData.ammoPistol,
            gunActive = GameData.gunActive,
            aidKits = GameData.aidKits
        };

        // using JsonUtility to serealise the save object to JSON
        string json = JsonUtility.ToJson(saveObj, true);

        Debug.Log(json);

        // making a new file and writing the json data
        // temporary commenting the saving beacuse of an error while playing on deployed site
        File.WriteAllText(Application.dataPath + "/SaveData/saveGame1.json", json);
    }

    // save object stores all the save data for the game
    private class SaveObject
    {
        public Vector3 playerPosition;
        public DarkSeekerObject[] enemies;
        public bool win;
        public int goals;
        public int playerHealth;
        public bool hasRifle;
        public bool hasPistol;
        public int ammoRifle;
        public int ammoPistol;
        public int gunActive;
        public int aidKits;
    }

    // class to store the enemy names and positions
    [System.Serializable]
    private class DarkSeekerObject
    {
        public string name;
        public Vector3 position;
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void onPauseButtonPressed()
    {
        pauseGame();
    }

    public void SelectRifle()
    {
        Debug.Log("Rifle Selected");
        GameData.gunActive = 1;
        rifle.SetActive(true);
        pistol.SetActive(false);
    }

    public void SelectPistol()
    {
        Debug.Log("Pistol Selected");
        GameData.gunActive = 2;
        rifle.SetActive(false);
        pistol.SetActive(true);
    }

    public void UseMedkit()
    {
        if (GameData.aidKits != 0)
        {
            GameData.aidKits--;
            GameData.playerHealth += 50;
        }
    }

    public void loadGame()
    {
        //Player Data
        player.controller.enabled = false;
        player.transform.position = sceneData.playerPosition;
        player.transform.rotation = sceneData.playerRotation;
        GameData.goals = sceneData.cures;
        DarkSeekerObject[] darkseekersSaveArray = new DarkSeekerObject[numOfDarkSeekers];

        for (int i = 0; i < darkseekers.Length; i++)
        {
            darkseekers[i].transform.position = sceneData.darkSeekersPosition[i];
        }

        player.controller.enabled = true;

        player.health = sceneData.playerHealth;
        player.playerHealthBar.SetHealth(sceneData.playerHealth);


    }

    public void onLoadButtonPressed()
    {
        loadGame();
    }

    public void saveGame()
    {
        //player saving data
        sceneData.playerPosition = player.transform.position;
        sceneData.playerHealth = player.health;
        sceneData.playerRotation = player.transform.rotation;
        sceneData.cures = GameData.goals;
        //enemy saving data
        DarkSeekerObject[] darkseekersSaveArray = new DarkSeekerObject[numOfDarkSeekers];
        sceneData.darkSeekersPosition = new Vector3[darkseekersSaveArray.Length];
        for (int i = 0; i < darkseekers.Length; i++)
        {
            sceneData.darkSeekersPosition[i] = darkseekers[i].transform.position;
        }
    }

    public void onSaveButtonPressed()
    {
        saveGame();
    }
}
