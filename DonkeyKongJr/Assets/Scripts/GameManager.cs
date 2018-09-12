using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    public LivesController livesController;
    public KeyController keyController;
    public DonkeyKongBigController donkeyKongBigController;

    public float spawnInterval = 2f;
    public float moveInterval = 0.5f;

    public Text score;
    public Text gameResult;
    private int currentScore;

    [HideInInspector]
    public bool gameContinue = true;
    // Use this for initialization

    void Start () {
        StartCoroutine(SpawnNewDemon());
        keyController.gameManager = this;
        donkeyKongBigController.gameManager = this;
        score.text = "";
        gameResult.text = " ";
        currentScore = 0;

    }
    
    //Spwan new demon with interval of spwan interval
    IEnumerator SpawnNewDemon()
    {
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
        //To check score each move
    }

    public void GameOver()
    {
        if (livesController.lives == 0)
        {
            gameContinue = false;
            Destroy(player);
            gameResult.text = "Game Over!";
        }
    }
    
    //public void CheckScore()
    public void CheckScore(Transform transform)
    {
        LayerMask playerLayer = LayerMask.GetMask("DK");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 2.5f, playerLayer);
        if(hit.rigidbody != null)
        {
            currentScore += 10;
        }
        score.text = currentScore.ToString();
    }
}