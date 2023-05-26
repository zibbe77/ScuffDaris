using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragClick : MonoBehaviour
{
    Camera myCam;

    //grafic
    [SerializeField]
    RectTransform boxVisual;

    //Logic
    Rect selectionBox;
    Vector2 startPositon;
    Vector2 endPositon;

    void Start()
    {
        myCam = Camera.main;
        startPositon = Vector2.zero;
        endPositon = Vector2.zero;
        DrawVisual();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            startPositon = Mouse.current.position.ReadValue();
            selectionBox = new Rect();
        }

        if (Mouse.current.leftButton.isPressed)
        {
            endPositon = Mouse.current.position.ReadValue();
            DrawVisual();
            DrawSelection();
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            selectObjects();
            startPositon = Vector2.zero;
            endPositon = Vector2.zero;
            DrawVisual();
        }
    }

    void DrawVisual()
    {
        Vector2 boxStart = startPositon;
        Vector2 boxEnd = endPositon;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        boxVisual.sizeDelta = boxSize;
    }

    void DrawSelection()
    {
        //do x 
        if (Mouse.current.position.ReadValue().x < startPositon.x)
        {
            //draing left
            selectionBox.xMin = Mouse.current.position.ReadValue().x;
            selectionBox.xMax = startPositon.x;
        }
        else
        {
            //draging right
            selectionBox.xMin = startPositon.x;
            selectionBox.xMax = Mouse.current.position.ReadValue().x;
        }

        //do y
        if (Mouse.current.position.ReadValue().y < startPositon.y)
        {
            selectionBox.yMin = Mouse.current.position.ReadValue().y;
            selectionBox.yMax = startPositon.y;
        }
        else
        {
            selectionBox.yMin = startPositon.y;
            selectionBox.yMax = Mouse.current.position.ReadValue().y;
        }


    }

    void selectObjects()
    {
        foreach (GameObject obj in ObjectSelction.Instance.objectList)
        {
            if (selectionBox.Contains(myCam.WorldToScreenPoint(obj.transform.position)))
            {
                ObjectSelction.Instance.DragSelect(obj.transform.GetChild(0).gameObject);
            }
        }
    }
}
