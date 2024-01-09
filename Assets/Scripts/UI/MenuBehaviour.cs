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

    private void Update() 
    {
        if(Input.anyKey) 
        {
            StartCoroutine(BlackScreen(2.0f));
            SceneManager.LoadScene(1);
        }

        if (PlayerPrefs.GetInt("GamePlayed") == 1)
        {
            lastScore.SetActive(true);    
            lastScoreText.SetText("HIGHSCORE: " + PlayerPrefs.GetInt("Highscore").ToString());
        }
    }

    private IEnumerator BlackScreen(float delay) 
    {
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(delay);
    }
}
