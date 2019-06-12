using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI HighScoreText;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    int currentScore = 0;

    void Start()
    {
        HighScoreText.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        currentScore = 0;
        SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void callGameOver(){
        StartCoroutine(GameOver());
    }
    IEnumerator GameOver(){
        yield return new WaitForSeconds(0.72f);
        gameOverPanel.SetActive(true);
        yield break;
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
    public void AddScore(int scr){
        Debug.Log(scr);
        currentScore += scr;
        SetScore();
    }
    public void SetScore(){
        currentScoreText.text = currentScore.ToString();
        if(currentScore > PlayerPrefs.GetInt("HighScore",0)){
            HighScoreText.text = currentScoreText.text;
            PlayerPrefs.SetInt("HighScore" , currentScore);
        }
    }
}
