using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    [SerializeField] GameObject blackScreen;
    void Update() {

        if(Input.anyKey) {
            //Change scene
            StartCoroutine(BlackScreen(2.0f));
            SceneManager.LoadScene(1);
        }
    } 

    IEnumerator BlackScreen(float delay) {
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(delay);
    }
}
