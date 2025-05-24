using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Text GameObject'leri public olarak tan�ml�yoruz
    public GameObject highscoreText;
    public GameObject player1Text;
    public GameObject player2Text;
    public GameObject lastScoreText; // Yeni eklenen Last Score Text

    void Start()
    {
        // Giri� ekran�nda t�m textleri gizliyoruz
        highscoreText.SetActive(false);
        player1Text.SetActive(false);
        player2Text.SetActive(false);
        lastScoreText.SetActive(false); // LastScoreText de gizleniyor
    }

    public void OnGameStart()
    {
        // Oyun ba�lad���nda t�m textleri aktif ediyoruz
        highscoreText.SetActive(true);
        player1Text.SetActive(true);
        player2Text.SetActive(true);
        lastScoreText.SetActive(true); // LastScoreText aktif ediliyor
    }
}
