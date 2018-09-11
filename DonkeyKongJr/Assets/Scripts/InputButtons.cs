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

    private void Start()
    {
#if UNITY_ANDROID
        transform.gameObject.SetActive(false);
#endif
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && LeftButtonPressed != null)
            LeftButtonPressed();
        else if (Input.GetKeyDown(KeyCode.RightArrow) && RightButtonPressed != null)
            RightButtonPressed();

        if (Input.GetKeyDown(KeyCode.UpArrow) && UpButtonPressed != null)
            UpButtonPressed();
    }

    private void OnMouseDown()
    {
        if (UpButtonPressed != null && up)
            UpButtonPressed();
        else if (LeftButtonPressed != null && left)
            LeftButtonPressed();
        else if (RightButtonPressed != null)
            RightButtonPressed();
    }

}
