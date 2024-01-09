using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAddRemove : MonoBehaviour
{
    private void Awake()
    {
            GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();

            foreach (GameObject obj in gameObjects)
            {
                DontDestroy dontDestroyScript = obj.GetComponent<DontDestroy>();

                if (dontDestroyScript != null)
                {
         
                    obj.AddComponent<DontDestroy>();
                }
            }
    }
}
