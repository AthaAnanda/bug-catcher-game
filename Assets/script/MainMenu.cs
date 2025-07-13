using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnStartGame()
    {
        GameManager.instance.StartGame();
    }

    // public void OnQuitGame()
    // {
    //     GameManager.instance.QuitGame();
    // }
}
