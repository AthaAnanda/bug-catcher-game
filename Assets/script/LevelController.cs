using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Scene Settings")]
    [Tooltip("Masukkan nama scene game utama di sini")]
    public string gameSceneName = "BugCatcherGame"; // Ganti sesuai nama scene game kamu

    // Fungsi untuk tombol Start Game
    public void StartGame()
    {
        if (!string.IsNullOrEmpty(gameSceneName))
        {
            SceneManager.LoadScene(gameSceneName);
        }
        else
        {
            Debug.LogError("Nama scene game belum diisi di Inspector!");
        }
    }

    // Fungsi untuk tombol Options (placeholder)
    public void OpenOptions()
    {
        Debug.Log("Menu Options belum tersedia.");
        // Kamu bisa nanti arahkan ke scene Options atau buka panel UI
    }

    // Fungsi untuk tombol Quit Game
    public void QuitGame()
    {
        Debug.Log("Keluar dari game...");
        Application.Quit();
    }
}
