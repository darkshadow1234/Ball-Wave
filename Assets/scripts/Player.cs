using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float yVelocity = 10.0f;
    bool yForce = true;
    float hueValue;
    bool isDead  = false;
    public GameObject deadEffectObj;
    public GameObject coinEffectObj;
    Rigidbody2D rb;
    float angle = 0;
    int xSpeed = 4;
    int ySpeed = 12;
    public float width = 3f;
    
    GameManager gameManager;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    void Start()
    {
        hueValue = Random.Range(0,10) / 10.0f;
        SetBackgroundColor();
    }

    
    void Update()
    {
        MovePlayer();
        GetInput();
    }
    void MovePlayer(){
        if(!isDead){
            Vector2 pos = transform.position;
            pos.x = Mathf.Cos(angle) * width;
            //pos.y = 0;
            transform.position = pos;
            angle += Time.deltaTime  * xSpeed;
        }
    }
    void GetInput(){
        if(Input.GetMouseButton(0)){
                if(yForce && rb.velocity.y < yVelocity){
                    rb.AddForce(new Vector2(0 , ySpeed));
                } else {
                    rb.velocity = new Vector2(rb.velocity.x , yVelocity);
                }
        } else {
            if(rb.velocity.y > 0)
                rb.AddForce(new Vector2(0 , -ySpeed));
            else 
                rb.velocity = new Vector2(rb.velocity.x , 0);
        }
    }
    

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "coin"){
            GetCoin(other);
        } else if(other.gameObject.tag == "obstacle"){
            Dead();
            other.gameObject.GetComponentInParent<Obstacle>().rbO.angularVelocity = 0f;
            other.gameObject.GetComponentInParent<Obstacle>().shouldMove = false;
        }
        else if(other.gameObject.tag == "obstacle score"){
            gameManager.AddScore(1);
            Debug.Log("1");
        }
    }
    void Dead(){
        StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake());
        Destroy(Instantiate(deadEffectObj , transform.position , Quaternion.identity) , 0.7f);
        StopPlayer();
        gameManager.callGameOver();
    }
    void GetCoin(Collider2D other){
        SetBackgroundColor();
        gameManager.AddScore(3);
        Destroy(Instantiate(coinEffectObj , other.gameObject.transform.position , Quaternion.identity) , 1f);
        Destroy(other.transform.parent.gameObject);
    }

    void StopPlayer(){
        rb.velocity = new Vector2(0,0);
        rb.isKinematic = true;
        isDead = true;
    }

    void SetBackgroundColor(){
        Camera.main.backgroundColor = Color.HSVToRGB(hueValue , 0.6f , 0.8f);

        hueValue += 0.1f;

        if(hueValue >=1){
            hueValue = 0;
        }
    }
}
