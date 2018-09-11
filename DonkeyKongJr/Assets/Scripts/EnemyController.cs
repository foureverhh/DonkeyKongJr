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

    public void OnTriggerEnter2D(Collider2D playerCollider)
    {
        //Debug.Log("OnTriggerEnter is called");
        //Debug.Log("demon collider is: " + transform.name + "Player collider is: " + playerCollider.name);
        if (playerCollider.tag == "Player")
        {
           // Debug.Log("demon collider is: " + transform.name + "Player collider is: " + playerCollider.name);
            Destroy(transform.parent.gameObject);
            gameManager.livesController.LifeDamage();
            gameManager.GameOver();
        }
    }
}
