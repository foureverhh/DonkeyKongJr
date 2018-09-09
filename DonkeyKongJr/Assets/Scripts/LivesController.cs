using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour {

    public int lives = 4;
    private float lifePadding = 1.2f;

	// Use this for initialization
	void Start () {
        SpawnLives();
	}

    void SpawnLives()
    {
        for( int i = 1; i < lives; i++)
        {
            GameObject newLife = Instantiate(transform.GetChild(0).gameObject);
            newLife.transform.SetParent(transform);
            Vector3 pos = transform.GetChild(0).transform.position;
            pos.x += i * lifePadding;
            newLife.transform.position = pos;
        }
    }
	
    void LifeDamage()
    {
        lives--;
        transform.GetChild(lives).gameObject.SetActive(false);
    }

    void RestoreLives()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(true);
    }
}
