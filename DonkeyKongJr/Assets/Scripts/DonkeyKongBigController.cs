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
            if (gameManager.player.GetComponentInChildren<PlayerController>().withKey)
            {
                transform.GetComponent<SpriteRenderer>().color = Color.green;
                //To shut down KeyView in key
                gameManager.keyController.gameObject.transform.parent.GetChild(1).transform.gameObject.SetActive(false);
                gameManager.gameResult.text = "You win";
                Destroy(gameManager.player);
                Destroy(gameManager.enemy);
            }     
        }
    }
}
