using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGridSlots : MonoBehaviour
{
    void Start()
    {
        PlanetGridManger.Instance.grid.Add(this.gameObject);
    }

    void OnDestroy()
    {
        PlanetGridManger.Instance.grid.Remove(this.gameObject);
    }
}
