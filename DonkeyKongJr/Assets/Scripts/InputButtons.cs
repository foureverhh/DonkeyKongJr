using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputButtons : MonoBehaviour {

    public bool left;
    public bool up;

    public delegate void ButtonPressed();
    public static event ButtonPressed LeftButtonPressed;
    public static event ButtonPressed RightButtonPressed;
    public static event ButtonPressed UpButtonPressed;

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (LeftButtonPressed != null && left && UpButtonPressed != null && up)
            UpButtonPressed();
        else if (LeftButtonPressed != null && left)
            LeftButtonPressed();
        else if (RightButtonPressed != null)
            RightButtonPressed();
    }

}
