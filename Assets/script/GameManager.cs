using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI & Data")]
    public GameObject menuPanel;
    public GameObject gamePanel;
    public GameObject pausePanel;
    public Text healthText;
    public Text scoreText;
    public Slider volumeSlider;

    [Header("Gameplay")]
    public int maxHealth = 3;
    private int health;
    private int score;

    [Header("Audio")]
    public AudioSource bgmSource;
    public AudioClip collectSound;
    public AudioClip hurtSound;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        MainMenu();
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void StartGame()
    {
        health = maxHealth;
        score = 0;
        UpdateUI();
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        SceneManager.LoadScene("Level1");
    }

    public void UpdateUI()
    {
        healthText.text = "❤️ " + health.ToString();
        scoreText.text = "Poin: " + score.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
        AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        UpdateUI();
        AudioSource.PlayClipAtPoint(hurtSound, Camera.main.transform.position);

        if (health <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextScene);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}