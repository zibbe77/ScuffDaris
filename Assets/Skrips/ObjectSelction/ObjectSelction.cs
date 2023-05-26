using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelction : MonoBehaviour
{
    public List<GameObject> objectList = new List<GameObject>();
    public List<GameObject> objectselceted = new List<GameObject>();

    //Make it so that only one can exist
    #region Singleton
    private static ObjectSelction _instance;
    public static ObjectSelction Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public void ClickSelect(GameObject objectToAdd)
    {
        DeselectAll();
        objectselceted.Add(objectToAdd);
        objectToAdd.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ShiftClickSelect(GameObject objectToAdd)
    {
        if (!objectselceted.Contains(objectToAdd))
        {
            objectselceted.Add(objectToAdd);
            objectToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            objectToAdd.transform.GetChild(0).gameObject.SetActive(false);
            objectselceted.Remove(objectToAdd);
        }
    }

    public void DragSelect(GameObject objectToAdd)
    {

    }

    public void DeselectAll()
    {
        foreach (var obj in objectselceted)
        {
            obj.transform.GetChild(0).gameObject.SetActive(false);
        }
        objectselceted.Clear();
    }

    public void Deselect(GameObject objectToAdd)
    {
        objectToAdd.transform.GetChild(0).gameObject.SetActive(false);
        objectselceted.Remove(objectToAdd);
    }
}
