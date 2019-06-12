using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform playerPosition;
    float smoothTime = 0.15f;
    Vector3 velocity = Vector3.zero;
    public int yOffset;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {  
        FollowPlayer(); 
    }
    void FollowPlayer(){
        Vector3 targetPosition = playerPosition.TransformPoint(new Vector3(0,yOffset , -10));
        targetPosition = new Vector3(0,targetPosition.y , targetPosition.z);
        transform.position = Vector3.SmoothDamp(transform.position , targetPosition , ref velocity , smoothTime);

    }
    
}
