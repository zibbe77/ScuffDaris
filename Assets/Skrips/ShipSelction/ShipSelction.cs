using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelction : MonoBehaviour
{
    public List<GameObject> shipList = new List<GameObject>();
    public List<GameObject> ShipSelceted = new List<GameObject>();


    #region Singleton
    private static ShipSelction _instance;
    public static ShipSelction Instance { get { return _instance; } }

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

}
