using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlanetGridManger : MonoBehaviour
{

    public List<GameObject> grid = new List<GameObject>();

    //Make it so that only one can exist
    #region Singleton
    private static PlanetGridManger _instance;
    public static PlanetGridManger Instance { get { return _instance; } }

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

    public void BuldingLayer()
    {
        foreach (GameObject slot in grid)
        {
            RawImage rawImage = slot.GetComponent<RawImage>();
            rawImage.color = Color.white;
        }
    }
    public void TransportLayer()
    {
        foreach (GameObject slot in grid)
        {
            RawImage rawImage = slot.GetComponent<RawImage>();
            rawImage.color = Color.red;
        }

    }
    public void TerrinLayer()
    {
        foreach (GameObject slot in grid)
        {
            RawImage rawImage = slot.GetComponent<RawImage>();
            rawImage.color = Color.blue;
        }
    }
}
