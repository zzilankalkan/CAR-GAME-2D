using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

using UnityEngine.SceneManagement;



public class Game_Controller : MonoBehaviour

{

    public Text highSoreText;

    public Text scoreText;



    private int score;

    private int highScore;



    public Score_Manager score_manager;



    public GameObject gamePausePanel;

    public GameObject gamePauseButton;




    public GameObject mainMenuPanel;  // Menü paneli
    public GameObject gameUI;         // Oyun sýrasýnda gösterilecek UI

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);  // Menü kapatýlýyor
        gameUI.SetActive(true);          // Oyun UI açýlýyor

        Time.timeScale = 1;              // Oyun devam ediyor
        Debug.Log("Oyun baþladý!");
    }





    // Start is called before the first frame update

    void Start()

    {

        gamePausePanel.SetActive(false);

        gamePauseButton.SetActive(true);

    }



    // Update is called once per frame

    void Update()

    {

        highScore = PlayerPrefs.GetInt("high_score");

        score = score_manager.score;



        highSoreText.text = "Highscore: " + highScore.ToString();

        scoreText.text = "Your Score: " + score.ToString();

    }



    public void Restart()

    {

        SceneManager.LoadScene("Game");

    }



    public void PauseGame()

    {

        Time.timeScale = 0;

        gamePausePanel.SetActive(true);

        gamePauseButton.SetActive(false);

    }



    public void ResumeGame()

    {

        Time.timeScale = 1;

        gamePausePanel.SetActive(false);

        gamePauseButton.SetActive(true);

    }



    public void Main_Menu()

    {

        SceneManager.LoadScene("Main_Menu");

    }




    public void ExitGame()
    {
        Debug.Log("Oyun kapatýlýyor...");  // Konsola mesaj yazdýrýr (sadece test amaçlý)
        Application.Quit();                 // Oyunun kapanmasýný saðlar (sadece build alýnca çalýþýr)
    }


}