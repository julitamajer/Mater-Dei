using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : ScenesToChange

{
    [SerializeField] Image loadingBar;

    void Start()
    {
        StartCoroutine(ProgressLoadingBar());
        ChangeScenes();
    }

    private IEnumerator ProgressLoadingBar()
    {
        while (loadingBar.fillAmount < 1f)
        {
            loadingBar.fillAmount += 0.1f;

            yield return new WaitForSeconds(1f);
        }
    }
}
