using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObject : MonoBehaviour
{
    void Start()
    {
        ObjectSelction.Instance.objectList.Add(this.gameObject);
    }

    void OnDestroy()
    {
        ObjectSelction.Instance.objectList.Remove(this.gameObject);
    }
}
