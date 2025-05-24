using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel; // Ana men� paneli
    public GameObject shopPanel;    // Ma�aza paneli

    public void StartGame()
    {
        // Oyun sahnesini y�kle
        SceneManager.LoadScene("EventSystem"); // Oyun sahnesinin ismini kontrol et
    }

   

    public void ExitGame()
    {
        // Oyundan ��k
        Debug.Log("Game is exiting...");
        Application.Quit();
    }
}
