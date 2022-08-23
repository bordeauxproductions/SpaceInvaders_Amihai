using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private int lives = 3;
    private static int highscore = 0; //Static - so we can save this info even after the scene was reloaded

    //Singletone class
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Score: " + score;
        GameObject.Find("LivesText").GetComponent<Text>().text = "Lives: " + lives;
        GameObject.Find("HighscoreText").GetComponent<Text>().text = "Highscore: " + highscore;
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int score)
    {
        this.score += score;
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Score: " + this.score;
        if (this.score > highscore) UpdateHighScore();
    }

    public void UpdateLives(int lives)
    {
        this.lives--;
        GameObject.Find("LivesText").GetComponent<Text>().text = "Lives: " + this.lives;
        if (this.score > highscore) UpdateHighScore();

        if (this.lives <= 0 || lives == -1) //"lives == -1" Means that we were hit by an Invader - Game Over
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Replace this later with Game Over Logic
        }

        else
        {
            Time.timeScale = 0.5f;
            Invoke(nameof(ReactionTime), 0.5f);
        }

    }

    private void ReactionTime()
    {
        Time.timeScale = 1.0f;
    }

    private void UpdateHighScore()
    {
        highscore = score;
        GameObject.Find("HighscoreText").GetComponent<Text>().text = "Highscore: " + highscore;
    }
}
