using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//To make devils move follow a time moveinterval
public class EnemyController : MonoBehaviour {

    public Transform demonPos;
    private int currentPos = 0;
    private float moveInterval = 0.5f;

	// Use this for initialization
	void Start () {
        //To get positions of Positions under Enemy
        //devilPos = enemyPrefab.GetComponentsInChildren<Transform>()[2].GetComponentsInChildren<Transform>();
        //Debug.Log(devilPos.childCount);
        StartCoroutine(DemonMove());
	}
	
	IEnumerator DemonMove()
    {
        while (true)
        {
            transform.position = demonPos.GetChild(currentPos).position;
            yield return new WaitForSeconds(moveInterval);
            DemonMoveToNext();
        }
    }

    void DemonMoveToNext()
    {
        currentPos++;
        if (currentPos > demonPos.childCount-1)
        {
            currentPos = 0;
        }
        transform.position = demonPos.GetChild(currentPos).position;
    }
}
