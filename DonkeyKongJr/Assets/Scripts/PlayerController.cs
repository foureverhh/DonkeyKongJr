using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject gameZone;
    public float horizontalMoveAmount;
    public float veriticalMoveAmont;
    public float stayInAir;
    public float pushUp;

    public bool withKey;
    private bool addPush ;
    private bool startLinear;
    private Rigidbody2D rd;

    private Vector3 startPos;
    private Vector3 endPos;

    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

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
        if (transform.position.x < 5.2)
        {
            Vector3 pos = transform.position;
            pos.x = pos.x + horizontalMoveAmount;
            transform.position = pos;
        }
    }

    private void Move_ToLeft()
    {
        //Debug.Log("Left is called");
        if (transform.position.x > -5.2)
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
            Transform secondFloor = gameZone.transform.GetChild(1); 
            Debug.Log("Floor is: " + secondFloor.gameObject.name);
            float offsetY = secondFloor.position.y - transform.position.y;

            Vector3 pos = transform.position;
            pos.y = pos.y + offsetY - 1.5f;   
            transform.position = pos;
   
            addPush = true;
        }
        else if (transform.position.y < -1.3)
        {
            startLinear = true;
        }
    }

    bool UnderCeiling()
    {
       // Debug.Log("UnderSecondFloor is called");
        LayerMask ceiling = LayerMask.GetMask("Ceiling");
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.up,Mathf.Infinity,ceiling);
        if (hit.collider != null)
            return true;
        else
            return false;
    }

    private void FixedUpdate()
    {
         if (startLinear)
        {
            StartCoroutine(RaiseUp());
        }

        if (addPush)
        {
            StartCoroutine(DownSlowly());
        }

    }
    IEnumerator RaiseUp()
    {
        rd.AddForce(transform.up * 300f);
        yield return new WaitForSeconds(pushUp);
        //StartCoroutine(DownSlowly());
        startLinear = false;
    }
    IEnumerator DownSlowly()
    {
        rd.AddForce(transform.up * 100f);
        yield return new WaitForSeconds(stayInAir);
        addPush = false;
    }

}
