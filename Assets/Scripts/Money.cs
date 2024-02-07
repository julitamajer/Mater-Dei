using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class Money : MonoBehaviour, ILootable
{
    UIBehaviour uiIBehaviour;

    private void Start()
    {
        FindUIBehaviour();
    }

    private void FindUIBehaviour()
    {
        // Find all Canvas objects in the scene
        Canvas[] canvases = FindObjectsOfType<Canvas>();

        // Loop through each Canvas to check if it has the UIBehaviour script
        foreach (Canvas canvas in canvases)
        {
            // Check if the Canvas has the UIBehaviour script attached
            UIBehaviour behaviour = canvas.GetComponent<UIBehaviour>();
            if (behaviour != null)
            {
                // Canvas with the UIBehaviour script found
                Debug.Log("Canvas with UIBehaviour script found: " + canvas.name);
                uiIBehaviour = behaviour;
                // You can do further operations here with the canvas if needed
                return; // Found the UIBehaviour, no need to continue searching
            }
        }

        // If UIBehaviour is not found, log a warning
        Debug.LogWarning("UIBehaviour script not found in any Canvas object.");
    }

    public void CollectMoney(int worth)
    {
        if (uiIBehaviour != null)
        {
            //uiIBehaviour.AddScoreMoney(worth);
        }
        else
        {
            Debug.LogWarning("UIBehaviour is not assigned. Money not added to score.");
        }
    }

}
