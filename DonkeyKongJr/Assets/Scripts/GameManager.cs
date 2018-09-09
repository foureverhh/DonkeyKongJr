using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    public LivesController livesController;


    public float spawnInterval = 4f;
    public float moveInterval = 0.5f;

    private bool gameContinue = true;
    // Use this for initialization

    void Start () {
        StartCoroutine(SpawnNewDemon());
	}
	
	// Update is called once per frame
	void Update () {
       // GameOver();
	}
    
    //Spwan new demon with interval of spwan interval
    IEnumerator SpawnNewDemon()
    {
        Debug.Log("Game continue in SpwanNewDemom is "+gameContinue);
        while (gameContinue)
        {
            NewDemon(moveInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void NewDemon(float moveInterval)
    {
        GameObject demon = Instantiate(enemy);
        EnemyController enemyController = demon.GetComponentInChildren<EnemyController>();
        enemyController.moveIntervalControll = moveInterval;
        //To make OnTriggerEnter2D work, assign a gameManager to new created demon 
        enemyController.gameManager = this;
        GameOver();
    }

    public void GameOver()
    {
        if (livesController.lives == 0)
        {
            gameContinue = false;
            Destroy(player);
        }
         Debug.Log("Gamecontinue is: " + gameContinue);
    }
    
}