using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectKlick : MonoBehaviour
{
    private Camera myCam;

    public LayerMask clickable;
    public LayerMask ground;

    void Start()
    {
        myCam = Camera.main;
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out hit, 5000f, clickable))
            {
                if (Keyboard.current.shiftKey.isPressed)
                {
                    ObjectSelction.Instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else
                {
                    ObjectSelction.Instance.ClickSelect(hit.collider.gameObject);
                }
            }
            else
            {
                if (!Keyboard.current.shiftKey.isPressed)
                {
                    ObjectSelction.Instance.DeselectAll();
                }
            }
        }
    }
}
