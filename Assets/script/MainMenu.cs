using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game"); // Pastikan ada scene bernama "Game"
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("LoadGame"); // Bisa kamu buat nanti
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings"); // Pastikan ada scene Settings
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit(); // Ini hanya akan bekerja di versi Build, bukan di Editor
    }
}
