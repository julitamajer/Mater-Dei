using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField] GameObject blackScreen;
    [SerializeField] GameObject lastScore;
    [SerializeField] TextMeshProUGUI lastScoreText;

    void Update() {

        if(Input.anyKey) {
            //Change scene
            StartCoroutine(BlackScreen(2.0f));
            SceneManager.LoadScene(1);
        }

        if (PlayerPrefs.GetInt("GamePlayed") == 1)
        {
            lastScore.SetActive(true);    
            lastScoreText.SetText("HIGHSCORE: " + PlayerPrefs.GetInt("Highscore").ToString());
        }
    } 

    IEnumerator BlackScreen(float delay) {
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(delay);
    }
}
