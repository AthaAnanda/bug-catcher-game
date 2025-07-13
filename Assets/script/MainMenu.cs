using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnLoadGame()
    {
        // Tambahkan sistem load jika ada, untuk sekarang sama seperti StartGame
        SceneManager.LoadScene("Level1");
    }

    public void OnQuitGame()
    {
        Application.Quit();
        Debug.Log("Keluar dari game"); // hanya muncul saat testing editor
    }
}
