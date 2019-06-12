using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coin;
    ObstacleManager obstacleManager;
    void Start()
    {
        obstacleManager = GameObject.Find("ObstacleManager").GetComponent<ObstacleManager>();
    }

    public void SpawnCoin(){
        Vector3 lowerPosition = obstacleManager.lastPosition;
        Vector3 upperPosition = obstacleManager.newPosition;
        Vector3 coinPosition = new Vector3( Random.Range(-2.5f , 2.5f) , Random.Range(lowerPosition.y + 1.2f , upperPosition.y-2f) , lowerPosition.z );
        Debug.Log(lowerPosition.x.ToString() +"~"+ lowerPosition.y.ToString() + "\n" + coinPosition.x.ToString()+"~" + coinPosition.y.ToString() +"\n" +upperPosition.x.ToString() +"~" +upperPosition.y.ToString() );
        Instantiate(coin , coinPosition , Quaternion.identity);
    }
}
