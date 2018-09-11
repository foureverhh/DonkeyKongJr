using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject gameZone;
    public float horizontalMoveAmount = 1.5f;
    public float veriticalMoveAmont = 1.5f;

    public bool withKey;

    private void OnEnable()
    {
        InputButtons.LeftButtonPressed += Move_ToLeft;
        InputButtons.RightButtonPressed += Move_ToRight;
        InputButtons.UpButtonPressed += Move_ToUp;
    }


    private void OnDisable()
    {
        InputButtons.LeftButtonPressed -= Move_ToLeft;
        InputButtons.RightButtonPressed -= Move_ToRight;
        InputButtons.UpButtonPressed -= Move_ToUp;
    }

    private void Move_ToRight()
    {
        //Debug.Log("Right is called");
        if (transform.position.x <5)
        {
            Vector3 pos = transform.position;
            pos.x = pos.x + horizontalMoveAmount;
            transform.position = pos;
        }
    }



    private void Move_ToLeft()
    {
        //Debug.Log("Left is called");
        if (transform.position.x > -5)
        {
            Vector3 pos = transform.position;
            pos.x = pos.x - horizontalMoveAmount;
            transform.position = pos;
        }
    }

    private void Move_ToUp()
    {
        //Debug.Log("Left and up is called");
        bool touchCeiling = UnderCeiling();
        //Debug.Log("touchCeiling is: "+touchCeiling);
        if (touchCeiling)
        {
            //Get Transform of SecondFloor
            Transform secondFloor = gameZone.GetComponentsInChildren<Transform>()[2];
           // Debug.Log("SecondFloor is: "+secondFloor.gameObject.name);
           // Debug.Log("player Y is: " + transform.position.y);
           // Debug.Log("second floor Y is: " + secondFloor.position.y);
            float offsetY = secondFloor.position.y - transform.position.y;

           // Debug.Log("offsetY is: " + offsetY);
      
            Vector3 pos = transform.position;
            pos.y = pos.y + offsetY-0.6f;
           // Debug.Log("pos.y is:" + pos.y);
            transform.position = pos;
           // Debug.Log("player after jump Y is: " + transform.position.y);
        }
        else if (transform.position.y <-0.3)
        {
            Vector3 pos = transform.position;
            pos.y = pos.y + veriticalMoveAmont;
            transform.position = pos;
        }
    }

    bool UnderCeiling()
    {
       // Debug.Log("UnderSecondFloor is called");
        LayerMask touchCeiling = LayerMask.GetMask("Ceiling");
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.up,Mathf.Infinity,touchCeiling);
        if (hit.collider != null)
            return true;
        else
            return false;
    }


}
