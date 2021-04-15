using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 15th Apr 2020
 */
public class AchieveControllerGameOver : MonoBehaviour
{
    public GameObject achieveText;

    public AudioSource SFXSource;
    public AudioClip sfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameData.winWithoutGun && GameData.win)
        {
            if (GameData.gunActive == 0)
            {
                //Achievement win without gun
                GameData.winWithoutGun = true;
                StartCoroutine(AchievementE(2));
            }
        }

        if (!GameData.winOnce && GameData.win)
        {
            //Achievement win once
            GameData.winOnce = true;
            StartCoroutine(AchievementE(1));
        }

        if (!GameData.loseOnce && !GameData.win)
        {
            //Achievements lose once
            GameData.loseOnce = true;
            StartCoroutine(AchievementE(3));
        }
    }
    public IEnumerator AchievementE(int achieve)
    {
        if (achieve == 1)
        {
            achieveText.SetActive(true);
            achieveText.GetComponent<TMP_Text>().text = "Win a Game";
            SFXSource.PlayOneShot(sfx);
        }
        else if (achieve == 2)
        {
            achieveText.SetActive(true);
            achieveText.GetComponent<TMP_Text>().text = "Win a Game without a Weapon";
            SFXSource.PlayOneShot(sfx);
        }
        else if (achieve == 3)
        {
            achieveText.SetActive(true);
            achieveText.GetComponent<TMP_Text>().text = "Lose a Game";
            SFXSource.PlayOneShot(sfx);
        }

        yield return new WaitForSeconds(6);

        achieveText.SetActive(false);
    }
}
