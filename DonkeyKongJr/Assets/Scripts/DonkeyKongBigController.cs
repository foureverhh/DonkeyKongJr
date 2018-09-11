using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyKongBigController : MonoBehaviour {

    [HideInInspector]
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(gameManager.player.GetComponentInChildren<PlayerController>().withKey)
                transform.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
