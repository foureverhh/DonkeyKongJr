using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//To make devils move follow a time moveinterval
public class EnemyController : MonoBehaviour {

    [HideInInspector]
    public GameManager gameManager;
    public Transform demonPos;
    private int currentPos = 0;
    [HideInInspector]
    public float moveIntervalControll;

	// Use this for initialization
	void Start () {
        StartCoroutine(DemonMove(moveIntervalControll));
	}
	
	IEnumerator DemonMove(float moveIntervalControll)
    {
        while (true)
        {
            yield return new WaitForSeconds(moveIntervalControll);
            transform.position = demonPos.GetChild(currentPos).position;
            DemonMoveToNext();
        }
    }

    void DemonMoveToNext()
    {
        currentPos++;
        if (currentPos > demonPos.childCount-1)
        {
            Destroy(transform.parent.gameObject);
            currentPos = 0;
        }
        transform.position = demonPos.GetChild(currentPos).position;
        gameManager.CheckScore(transform);
    }

    public void OnTriggerEnter2D(Collider2D Collider)
    {
        //Debug.Log("OnTriggerEnter is called");
        //Debug.Log("demon collider is: " + transform.name + "Player collider is: " + playerCollider.name);
        if (Collider.tag == "Player")
        {
      
            //Debug.Log("demon collider is: " + transform.name + "Player collider is: " + Collider.name);
            Destroy(transform.parent.gameObject);
            gameManager.livesController.LifeDamage();
            //Debug.Log("It is called");
            gameManager.GameOver();
           //Debug.Log("After all functions, demon collider is: " + transform.name + "Player collider is: " + Collider.name);
        }
        /*
        else
        {
            
            Debug.Log("Transform name is: " + transform.gameObject.name);
            Debug.Log("Transform position is: " + transform.position);
            Debug.Log("It runs here");
        }
            
        */
    }
}
