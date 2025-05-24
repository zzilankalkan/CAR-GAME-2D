using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel; // Ana menü paneli
    public GameObject shopPanel;    // Maðaza paneli

    public void StartGame()
    {
        // Oyun sahnesini yükle
        SceneManager.LoadScene("EventSystem"); // Oyun sahnesinin ismini kontrol et
    }

   

    public void ExitGame()
    {
        // Oyundan çýk
        Debug.Log("Game is exiting...");
        Application.Quit();
    }
}
