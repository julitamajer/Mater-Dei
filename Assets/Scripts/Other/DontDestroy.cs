using System.Xml.Linq;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    //[HideInInspector]
    public string objectID;

    private void Awake()
    {
        objectID = $"{name}_{transform.position.x}_{transform.position.y}_{transform.position.z}_{transform.eulerAngles.x}_{transform.eulerAngles.y}_{transform.eulerAngles.z}";
        Debug.Log($"Object {name} Awake - objectID: {objectID}");
    }

    void Start()
    {
        var dontDestroyObjects = Object.FindObjectsOfType<DontDestroy>();

        for (int i = 0; i < dontDestroyObjects.Length; i++)
        {
            if (dontDestroyObjects[i] != this && dontDestroyObjects[i].objectID == objectID)
            {
                Debug.Log($"Duplicate found: {name}. Destroying...");
                Destroy(dontDestroyObjects[i].gameObject);
                return; // Exit the loop early once a duplicate is found and destroyed
            }
        }

        Debug.Log($"Object {name} will not be destroyed.");
        DontDestroyObj();
    }

    public void DontDestroyObj()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
