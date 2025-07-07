using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("BugCatcherGame"); // atau index: LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Keluar"); // tidak akan keluar di Editor
    }
}
