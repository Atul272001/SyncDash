using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] GameObject gameOverPannel;
    //[SerializeField] GameObject mainMenuPannel;
    [SerializeField] Text highScore;

    private void Awake()
    {
        instance = this;

        if(highScore)
            highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();

    }

    public void StartGame()
    {
        OpenLevel(1);
    }

    public void MainMenu()
    {
        OpenLevel(0);
    }

    public void Restart()
    {
        OpenLevel(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void OpenLevel(int lvlNum)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(lvlNum);
    }

    public void GameOver()
    {
        gameOverPannel.SetActive(true);
    }

}
