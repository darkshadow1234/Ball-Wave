using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed3 = 3f;
    bool toRight = false; public bool shouldMove = true;
    public int chance = 4;
    bool spawnOrNot = true;
    ObstacleManager obstacleManager;
    CoinManager coinManager;
    Transform playerObj;
    int variable = 0;
    public Rigidbody2D rbO;
    public Transform trO;
    void Start(){
        shouldMove = true;
        playerObj = GameObject.Find("player").GetComponent<Transform>();
        obstacleManager = GameObject.Find("ObstacleManager").GetComponent<ObstacleManager>();
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        variable = Random.Range(0,chance);
        if(variable == 1){
            trO.localScale = new Vector2(2.3f , 0.5f);
            trO.position = new Vector3(0,transform.position.y , transform.position.z);
            rbO.angularVelocity = 100f;
        } else if(variable == 2){
            trO.localScale = new Vector2(2f , 0.5f);
        } else if(variable == 3){
            trO.localScale = new Vector2(2f , 0.5f);
            if(Random.Range(0,2) == 1){
                trO.position = new Vector2(-1.9f,trO.position.y );
                toRight = true;
            } else {
                trO.position = new Vector2(+1.9f,trO.position.y );
                toRight = false;
            }
        }
    }
    void Update()
    {
        if(playerObj.position.y > transform.position.y && spawnOrNot){
            obstacleManager.SpawnObstacle();
            coinManager.SpawnCoin();
            spawnOrNot = false;
        }
        if(playerObj.position.y > transform.position.y + 5){
            Destroy(gameObject);
        }
        if(variable == 3 && shouldMove){
            if(trO.position.x >= 1.9f){
                toRight = false;
            } else if(trO.position.x <= -1.9){
                toRight = true;
            }
            if(toRight ){
                trO.position = new Vector2(trO.position.x +  (Time.deltaTime * speed3) , trO.position.y);
            } else if(!toRight){
                trO.position = new Vector2(trO.position.x +  (Time.deltaTime * (-speed3)) , trO.position.y);
            }
        }
    }
}
