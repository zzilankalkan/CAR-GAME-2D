using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Skor deðiþkenleri
    public int player1Score = 0;
    public int player2Score = 0;

    // Skor UI Text objeleri
    public Text player1ScoreText;
    public Text player2ScoreText;

    private void Awake()
    {
        // Singleton Pattern: GameManager'ý tek bir instance yapýyoruz.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Skorlarý güncelleyen metot
    public void UpdateScoreUI()
    {
        player1ScoreText.text = "PLAYER1: " + player1Score;
        player2ScoreText.text = "PLAYER2: " + player2Score;
    }

}
