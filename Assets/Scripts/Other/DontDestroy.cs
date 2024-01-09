using System.Xml.Linq;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    string objectID;

    private void Awake()
    {
        objectID = $"{name}_{transform.position.x}_{transform.position.y}_{transform.position.z}_{transform.eulerAngles.x}_{transform.eulerAngles.y}_{transform.eulerAngles.z}";
    }

    private void Start()
    {
        var dontDestroyObjects = Object.FindObjectsOfType<DontDestroy>();

        for (int i = 0; i < dontDestroyObjects.Length; i++)
        {
            if (dontDestroyObjects[i] != this && dontDestroyObjects[i].objectID == objectID)
            {
                Destroy(dontDestroyObjects[i].gameObject);
                return; 
            }
        }

        DontDestroyObj();
    }

    public void DontDestroyObj()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
