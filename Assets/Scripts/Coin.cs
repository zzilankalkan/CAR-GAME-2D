using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Oyuncu 1 mi �arpt�?
        if (collision.gameObject.CompareTag("Player1"))
        {
            GameManager.instance.player1Score +=50; // Oyuncu 1'in skorunu art�r
            GameManager.instance.UpdateScoreUI(); // UI'yi g�ncelle
            Destroy(gameObject); // Coin'i yok et
        }
        // Oyuncu 2 mi �arpt�?
        else if (collision.gameObject.CompareTag("Player2"))
        {
            GameManager.instance.player2Score +=50; // Oyuncu 2'nin skorunu art�r
            GameManager.instance.UpdateScoreUI(); // UI'yi g�ncelle
            Destroy(gameObject); // Coin'i yok et
        }
    }
}
