using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Transform playerObj;
    GameManager gameManager;
    void Start()
    {
        playerObj = GameObject.Find("player").GetComponent<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerObj.position.y > transform.position.y + 5){
            Destroy(gameObject);
        }
    }
}
