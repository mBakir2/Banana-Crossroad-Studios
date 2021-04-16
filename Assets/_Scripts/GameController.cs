using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 15th Apr 2020
 */
public class GameController : MonoBehaviour
{
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
    public GameObject uirifle;
    public GameObject uipistol;

    public GameObject rifle;
    public GameObject pistol;

    [Header("Player Settings")]
    public PlayerBehaviour player;
    public CameraController playerCamera;

    [Header("Dark Seeker Settings")]
    public DarkSeekerBehaviour[] darkseekers;
    public GameObject darkseekerPrefab;

    [Header("Scene Data")]
    public SceneDataSO sceneData;

    [Header("Prefabs to instantiate on Load")]
    public GameObject goalPref;
    public GameObject pistolPref;
    public GameObject riflePref;
    public GameObject ammoPref;
    public GameObject firstAidPref;

    //achievement system variables
    private int compareDark;
    private int compareCure;
    private int latest = 0;
    [Header("Achievement Popup")]
    public GameObject achieveText;
    public GameObject achievementUI;
    public AudioSource SFXSource;
    public AudioClip sfx;

    [Header("Tutorial Manager")]
    public GameObject tutorialManager;

    private bool gameHasLoadedOnce = true;
    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<PlayerBehaviour>();
        darkseekers = FindObjectsOfType<DarkSeekerBehaviour>();
        playerCamera = FindObjectOfType<CameraController>();
        compareCure = FindObjectsOfType<Goal>().Length;
        compareDark = darkseekers.Length;
        Time.timeScale = 1f;

        //if (GameData.loadFromMainMenu)
        //{
        //    Debug.Log("Loading the game");
        //    loadGame();
        //}
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
        if (GameData.goals >= GameData.totalgoals)
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
        //if (Input.GetKeyDown(KeyCode.I) && !inventory.activeSelf)
        //{
        //    inventory.SetActive(true);
        //    //Cursor.lockState = CursorLockMode.None;
        //}
        //else if (Input.GetKeyDown(KeyCode.I))
        //{
        //    inventory.SetActive(false);
        //    //Cursor.lockState = CursorLockMode.Locked;
        //}

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

        //achievement check for two achievements
        if (!GameData.killOnce)
        {
            if (compareDark > FindObjectsOfType<DarkSeekerBehaviour>().Length)
            {
                GameData.killOnce = true;
                latest = 2;
                StartCoroutine(Achievement());
            }
        }
        if (!GameData.cureOnce)
        {
            if (compareCure > FindObjectsOfType<Goal>().Length)
            {
                GameData.cureOnce = true;
                latest = 1;
                StartCoroutine(Achievement());
            }
        }

        if (gameHasLoadedOnce)
        {
            if (GameData.loadFromMainMenu)
            {
                Debug.Log("Loading the game");
                loadGame();
            }

            if (GameData.loadTutorial)
            {
                Debug.Log("Loading the tutorial");
                loadTutorial();
            }
            gameHasLoadedOnce = false;
        }
    }


    public IEnumerator Achievement()
    {
        if (latest == 1)
        {
            achieveText.SetActive(true);
            achieveText.GetComponent<TMP_Text>().text = "Delivered a Cure";
            SFXSource.PlayOneShot(sfx);
        }
        else if (latest == 2)
        {
            achieveText.SetActive(true);
            achieveText.GetComponent<TMP_Text>().text = "Killed a Darkseeker";
            SFXSource.PlayOneShot(sfx);
        }

        yield return new WaitForSeconds(5);

        achieveText.SetActive(false);
    }

    // resume the game
    public void UnPauseGC()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
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
    public class DarkSeekerObject
    {
        public string name;
        public Vector3 position;
        public int health;
    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void openInventory()
    {
        if (inventory.activeSelf)
        {
            inventory.SetActive(false);
        }
        else if (!inventory.activeSelf)
        {
            inventory.SetActive(true);
        }
    }

    public void openAchievements()
    {
        if (achievementUI.activeSelf)
        {
            achievementUI.SetActive(false);
        }
        else if (!achievementUI.activeSelf)
        {
            achievementUI.SetActive(true);
        }
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
            if (GameData.playerHealth > 50)
            {
                GameData.playerHealth = 100;
            }
            else
            {
                GameData.playerHealth += 50;
            }
        }
    }

    public void loadGame()
    {
        loadGameDataFromPlayerPrefs();
        //Player Data
        player.controller.enabled = false;
        player.transform.position = sceneData.playerPosition;
        player.transform.rotation = sceneData.playerRotation;
        player.controller.enabled = true;
        GameData.goals = sceneData.cures;


        DarkSeekerBehaviour[] darkseekersInScene = FindObjectsOfType<DarkSeekerBehaviour>();

        // destroying all current enemies
        for (int i = 0; i < darkseekersInScene.Length; i++)
        {
            Destroy(darkseekersInScene[i].gameObject);
        }

        // instantialing the new enemies from the load data
        for (int i = 0; i < sceneData.darkSeekersSaveData.darkSeekerObjectArray.Length; i++)
        {
            GameObject darkSeeker = Instantiate(darkseekerPrefab);
            darkSeeker.transform.position = sceneData.darkSeekersSaveData.darkSeekerObjectArray[i].darkSeekerPosition;
            darkSeeker.transform.rotation = sceneData.darkSeekersSaveData.darkSeekerObjectArray[i].darkSeekerRotation;
            //darkSeeker.gameObject.GetComponent<DarkSeekerBehaviour>().health = sceneData.darkSeekersSaveObjects[i].darkSeekerHealth;
            //darkSeeker.gameObject.GetComponent<DarkSeekerBehaviour>().enemyHealthBar.SetHealth(sceneData.darkSeekersSaveObjects[i].darkSeekerHealth);
        }

        //destroy all pickups and reinstantiate existing pickups on load
        //destroys

        PickupRifle[] rifles = FindObjectsOfType<PickupRifle>();
        PickupPistol[] pistols = FindObjectsOfType<PickupPistol>();
        PickupFirstAid[] firstAids = FindObjectsOfType<PickupFirstAid>();
        PickupAmmo[] ammos = FindObjectsOfType<PickupAmmo>();
        Goal[] goals = FindObjectsOfType<Goal>();

        for (int i = 0; i < rifles.Length; i++)
        {
            Destroy(rifles[i].gameObject);
        }
        for (int i = 0; i < pistols.Length; i++)
        {
            Destroy(pistols[i].gameObject);
        }
        for (int i = 0; i < firstAids.Length; i++)
        {
            Destroy(firstAids[i].gameObject);
        }
        for (int i = 0; i < ammos.Length; i++)
        {
            Destroy(ammos[i].gameObject);
        }
        for (int i = 0; i < goals.Length; i++)
        {
            Destroy(goals[i].gameObject);
        }
        

        //instantiates new pickups
        for (int i = 0; i < sceneData.riflePickup.Length; i++)
        {
            Instantiate(riflePref, sceneData.riflePickup[i], new Quaternion());
        }
        for (int i = 0; i < sceneData.pistolPickup.Length; i++)
        {
            Instantiate(pistolPref, sceneData.pistolPickup[i], new Quaternion());
        }
        for (int i = 0; i < sceneData.firstAidsPickup.Length; i++)
        {
            Instantiate(firstAidPref, sceneData.firstAidsPickup[i], new Quaternion());
        }
        for (int i = 0; i < sceneData.ammoPickup.Length; i++)
        {
            Instantiate(ammoPref, sceneData.ammoPickup[i], new Quaternion());
        }
        for (int i = 0; i < sceneData.goalsPickup.Length; i++)
        {
            Instantiate(goalPref, sceneData.goalsPickup[i], new Quaternion());
        }

        player.controller.enabled = true;

        player.health = sceneData.playerHealth;
        player.playerHealthBar.SetHealth(sceneData.playerHealth);
        GameData.playerHealth = sceneData.playerHealth;
        GameData.hasPistol = sceneData.hasPistol;
        GameData.hasRifle = sceneData.hasRifle;
        GameData.gunActive = sceneData.gunActive;
    }

    public void saveGame()
    {
        //player saving data
        sceneData.playerPosition = player.transform.position;
        sceneData.playerHealth = GameData.playerHealth;
        sceneData.playerRotation = player.transform.rotation;
        sceneData.cures = GameData.goals;

        DarkSeekerBehaviour[] darkseekersInScene = FindObjectsOfType<DarkSeekerBehaviour>();
        //enemy saving data
        DarkSeekerSaveObject[] darkSeekerSaveObjects = new DarkSeekerSaveObject[darkseekersInScene.Length];
        sceneData.darkSeekersPosition = new Vector3[darkseekersInScene.Length];
        sceneData.enemyRotation = new Quaternion[darkseekersInScene.Length];
        sceneData.enemyHealth = new int[darkseekersInScene.Length];

        for (int i = 0; i < darkseekersInScene.Length; i++)
        {
            darkSeekerSaveObjects[i] = new DarkSeekerSaveObject{
                darkSeekerPosition = darkseekersInScene[i].transform.position,
                darkSeekerHealth = darkseekersInScene[i].health,
                darkSeekerRotation = darkseekersInScene[i].transform.rotation
            };
            sceneData.darkSeekersPosition[i] = darkseekersInScene[i].transform.position;
            sceneData.enemyRotation[i] = darkseekersInScene[i].transform.rotation;
            sceneData.enemyHealth[i] = darkseekersInScene[i].health;
        }

        DarkSeekerSaveData darkSeekerSaveData = new DarkSeekerSaveData
        {
            darkSeekerObjectArray = darkSeekerSaveObjects
        };

        sceneData.darkSeekersSaveData = darkSeekerSaveData;

        //pickups goal data
        PickupRifle[] rifles = FindObjectsOfType<PickupRifle>();
        PickupPistol[] pistols = FindObjectsOfType<PickupPistol>();
        PickupFirstAid[] firstAids = FindObjectsOfType<PickupFirstAid>();
        PickupAmmo[] ammos = FindObjectsOfType<PickupAmmo>();
        Goal[] goals = FindObjectsOfType<Goal>();

        sceneData.riflePickup = new Vector3[rifles.Length];
        sceneData.pistolPickup = new Vector3[pistols.Length];
        sceneData.firstAidsPickup = new Vector3[firstAids.Length];
        sceneData.ammoPickup = new Vector3[ammos.Length];
        sceneData.goalsPickup = new Vector3[goals.Length];

        for (int i = 0; i < rifles.Length; i++)
        {
            sceneData.riflePickup[i] = rifles[i].transform.position;
        }
        for (int i = 0; i < pistols.Length; i++)
        {
            sceneData.pistolPickup[i] = pistols[i].transform.position;
        }
        for (int i = 0; i < firstAids.Length; i++)
        {
            sceneData.firstAidsPickup[i] = firstAids[i].transform.position;
        }
        for (int i = 0; i < ammos.Length; i++)
        {
            sceneData.ammoPickup[i] = ammos[i].transform.position;
        }
        for (int i = 0; i < goals.Length; i++)
        {
            sceneData.goalsPickup[i] = goals[i].transform.position;
        }

        sceneData.hasPistol = GameData.hasPistol;
        sceneData.hasRifle = GameData.hasRifle;
        sceneData.gunActive = GameData.gunActive;

        saveGameDataInPlayerPrefs();
    }

    public void onSaveButtonPressed()
    {
        saveGame();
    }

    // for saving the data in player prefs
    public void saveGameDataInPlayerPrefs()
    {
        // setting player position in player preferences
        PlayerPrefs.SetFloat("playerTransformX", sceneData.playerPosition.x);
        PlayerPrefs.SetFloat("playerTransformY", sceneData.playerPosition.y);
        PlayerPrefs.SetFloat("playerTransformZ", sceneData.playerPosition.z);

        // setting player rotation in player preferences
        PlayerPrefs.SetFloat("playerRotationX", sceneData.playerRotation.x);
        PlayerPrefs.SetFloat("playerRotationY", sceneData.playerRotation.y);
        PlayerPrefs.SetFloat("playerRotationZ", sceneData.playerRotation.z);
        PlayerPrefs.SetFloat("playerRotationW", sceneData.playerRotation.w);

        // setting player health in player prefrences
        PlayerPrefs.SetInt("playerHealth", sceneData.playerHealth);

        // setting cures delivered in player prefrences
        PlayerPrefs.SetInt("curesDelivered", sceneData.cures);

        PlayerPrefs.SetInt("hasPistol", (sceneData.hasPistol ? 1 : 0));
        PlayerPrefs.SetInt("hasRifle", (sceneData.hasRifle ? 1 : 0));
        PlayerPrefs.SetInt("gunActive", sceneData.gunActive);

        // making a new pickup items data class to enclose the pickup item lists
        PickupItemsData itemsData = new PickupItemsData
        {
            riflePickup = sceneData.riflePickup,
            pistolPickup = sceneData.pistolPickup,
            firstAidsPickup = sceneData.firstAidsPickup,
            ammoPickup = sceneData.ammoPickup,
            goalsPickup = sceneData.goalsPickup
        };

        // serializing both data wrapper classes into JSON to store as a string in player prefs
        string serializedData = JsonUtility.ToJson(sceneData.darkSeekersSaveData);
        string serializedItemPickupData = JsonUtility.ToJson(itemsData);

        Debug.Log(serializedData);

        PlayerPrefs.SetString("darkSeekersData", serializedData);
        PlayerPrefs.SetString("pickupData", serializedItemPickupData);
    }

    // loading the saved data from player preferences
    public void loadGameDataFromPlayerPrefs()
    {
        // geting data from player Prefs and setting in scene data
        sceneData.playerPosition.x = PlayerPrefs.GetFloat("playerTransformX");
        sceneData.playerPosition.y = PlayerPrefs.GetFloat("playerTransformY");
        sceneData.playerPosition.z = PlayerPrefs.GetFloat("playerTransformZ");

        sceneData.playerRotation.x = PlayerPrefs.GetFloat("playerRotationX");
        sceneData.playerRotation.y = PlayerPrefs.GetFloat("playerRotationY");
        sceneData.playerRotation.z = PlayerPrefs.GetFloat("playerRotationZ");
        sceneData.playerRotation.w = PlayerPrefs.GetFloat("playerRotationW");

        sceneData.playerHealth = PlayerPrefs.GetInt("playerHealth");

        sceneData.cures = PlayerPrefs.GetInt("curesDelivered");

        sceneData.hasPistol = (PlayerPrefs.GetInt("hasPistol") != 0);
        sceneData.hasRifle = (PlayerPrefs.GetInt("hasRifle") != 0);
        sceneData.gunActive = PlayerPrefs.GetInt("gunActive");

        // parsing the data from JSON and assigning it to the scene data
        sceneData.darkSeekersSaveData = JsonUtility.FromJson<DarkSeekerSaveData>(PlayerPrefs.GetString("darkSeekersData"));
        PickupItemsData itemsData = JsonUtility.FromJson<PickupItemsData>(PlayerPrefs.GetString("pickupData"));
        sceneData.riflePickup = itemsData.riflePickup;
        sceneData.pistolPickup = itemsData.pistolPickup;
        sceneData.firstAidsPickup = itemsData.firstAidsPickup;
        sceneData.ammoPickup = itemsData.ammoPickup;
        sceneData.goalsPickup = itemsData.goalsPickup;
    }

    public void loadTutorial()
    {
        tutorialManager.SetActive(true);
    }
}

// wrapper class for storing the item pickup arrays
[Serializable]
public class PickupItemsData
{
    [SerializeField]
    public Vector3[] riflePickup;
    [SerializeField]
    public Vector3[] pistolPickup;
    [SerializeField]
    public Vector3[] firstAidsPickup;
    [SerializeField]
    public Vector3[] ammoPickup;
    [SerializeField]
    public Vector3[] goalsPickup;
}

// wrapper class for storing dark seekers save data objects array
[Serializable]
public class DarkSeekerSaveData
{
    [SerializeField]
    public DarkSeekerSaveObject[] darkSeekerObjectArray;
}

// dark seekers save object class to save dark seekers position, rotation and health
[Serializable]
public class DarkSeekerSaveObject
{
    [SerializeField]
    public Vector3 darkSeekerPosition;
    [SerializeField]
    public Quaternion darkSeekerRotation;
    [SerializeField]
    public int darkSeekerHealth;
}
