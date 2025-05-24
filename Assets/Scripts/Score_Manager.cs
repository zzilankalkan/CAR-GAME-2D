using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour
{
    public int score = 0;
    public int highScore;
    public static int lastScore = 0;

    public Text scoreText;
    public Text highScoreText;
    public Text lastScoreText;

    void Start()
    {
        if (scoreText == null || highScoreText == null || lastScoreText == null)
        {
            Debug.LogError("Score Manager: Text components are not assigned in the Inspector!");
            return;
        }

        Debug.Log("HighScore from PlayerPrefs: " + PlayerPrefs.GetInt("high_score", 0));
        Debug.Log("LastScore: " + lastScore);

        StartCoroutine(ScoreRoutine());

        highScore = PlayerPrefs.GetInt("high_score", 0);
        highScoreText.text = "HighScore: " + highScore;
        lastScoreText.text = "LastScore: " + lastScore;
    }

    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("high_score", highScore);

            if (highScoreText != null)
            {
                highScoreText.text = "HighScore: " + highScore;
            }
        }
    }

    IEnumerator ScoreRoutine()
    {
        Debug.Log("ScoreRoutine started");
        while (true)
        {
            yield return new WaitForSeconds(0.8f);
            score++;
            lastScore = score;
        }
    }

    public void ResetScore()
    {
        score = 0;
        lastScore = 0;

        if (scoreText != null)
        {
            scoreText.text = "Score: 0";
        }

        if (lastScoreText != null)
        {
            lastScoreText.text = "LastScore: 0";
        }
    }
}
