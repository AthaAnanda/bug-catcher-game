using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public Text healthText, scoreText, timerText;
    public GameObject gameOverPanel;
    public Button restartButton, exitButton;

    [Header("Gameplay")]
    public int maxHealth = 3;
    public float gameTime = 60f; // default
    public AudioClip collectSound, hurtSound;

    private int health, score;
    private float currentTime;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name.StartsWith("Level"))
        {
            InitGameplay();
        }

        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitGame);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.StartsWith("Level"))
        {
            InitGameplay();

            if (gameOverPanel != null)
                gameOverPanel.SetActive(false);
        }
    }

    void InitGameplay()
    {
        Time.timeScale = 1;
        health = maxHealth;
        score = 0;

        // ✅ Atur waktu berdasarkan nama level
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level1":
                gameTime = 60f; break;
            case "Level2":
                gameTime = 90f; break;
            case "Level3":
                gameTime = 120f; break;
            default:
                gameTime = 60f; break;
        }

        currentTime = gameTime;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        StartCoroutine(TimerCountdown());
        UpdateUI();
    }

    IEnumerator TimerCountdown()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateUI();
            yield return null;
        }
        GameOver();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
        if (collectSound)
            AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        UpdateUI();
        if (hurtSound)
            AudioSource.PlayClipAtPoint(hurtSound, Camera.main.transform.position);

        if (health <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        if (healthText) healthText.text = "❤️: " + health;
        if (scoreText) scoreText.text = "Poin: " + score;
        if (timerText)
        {
            int m = Mathf.FloorToInt(currentTime / 60);
            int s = Mathf.FloorToInt(currentTime % 60);
            timerText.text = $"TIMER {m:00}:{s:00}";
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
