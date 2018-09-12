using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

    [HideInInspector]
    public GameManager gameManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Make key picture disappear
            transform.gameObject.SetActive(false);
            // let Donkeykong jr with key
            gameManager.player.transform.GetChild(0).GetComponent<PlayerController>().withKey = true;
            //Make keyview show
            transform.parent.GetChild(1).gameObject.SetActive(true);
        }
    }
}
