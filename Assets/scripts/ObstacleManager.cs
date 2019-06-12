using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public Vector3 lastPosition;
    public Vector3 newPosition;
    public GameObject playerObj;
    public GameObject obstacle;

    void Start(){
        SpawnObstacle();
    }

    public void SpawnObstacle(){
        Instantiate(obstacle , transform.position , Quaternion.identity);
        lastPosition = transform.position;
        transform.position = new Vector3(Random.Range(-2.5f , 2.5f) , transform.position.y + Random.Range(4.5f,5.0f) , transform.position.z);
        newPosition = transform.position;
    }
}
