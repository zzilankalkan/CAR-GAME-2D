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




    public GameObject mainMenuPanel;  // Men� paneli
    public GameObject gameUI;         // Oyun s�ras�nda g�sterilecek UI

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);  // Men� kapat�l�yor
        gameUI.SetActive(true);          // Oyun UI a��l�yor

        Time.timeScale = 1;              // Oyun devam ediyor
        Debug.Log("Oyun ba�lad�!");
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
        Debug.Log("Oyun kapat�l�yor...");  // Konsola mesaj yazd�r�r (sadece test ama�l�)
        Application.Quit();                 // Oyunun kapanmas�n� sa�lar (sadece build al�nca �al���r)
    }


}