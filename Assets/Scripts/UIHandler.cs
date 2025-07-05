using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiScore;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI gameOverScore;
    private const string HighScoreKey  = "HighScore"; 
    
    int score = 0;
    
    public void AddScore()
    {
        score++;
        uiScore.text = $"Score: {score.ToString()}";
    }

    public void HighScore()
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, score);
        }
        currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        gameOverScore.text = $"High Score: {currentHighScore.ToString()}";
    }
    
    public void GameOver()
    {
        HighScore();
        gameOverScreen.SetActive(true);
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
