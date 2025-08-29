using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiScore;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI gameOverScore;
    [SerializeField] private GameObject highScoreScreen;
    [SerializeField] private TextMeshProUGUI uiHighScoreScreen;
    [SerializeField] private GameObject highScoreResetPopUp;
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

    public void HighScoreScreen()
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        highScoreScreen.SetActive(true);
        uiHighScoreScreen.text = $"High Score: {currentHighScore.ToString()}";
    }

    public void CancelResetAndGoToMenu()
    {
        highScoreScreen.SetActive(false);
    }

    public void ResetHighScore()
    {
        int currentHighScore;
        PlayerPrefs.SetInt(HighScoreKey, 0);
        currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        uiHighScoreScreen.text = $"High Score: {currentHighScore.ToString()}";
        ShowPopUp();
        Invoke(nameof(HidePopUp), 0.7f);
    }

    private void ShowPopUp()
    {
        highScoreResetPopUp.SetActive(true);
    }

    private void HidePopUp()
    {
        highScoreResetPopUp.SetActive(false);
    }
}
