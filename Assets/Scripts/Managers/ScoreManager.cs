using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    bool gameOver;
    float currentScore;

    [SerializeField] Text scoreText;

    private void Awake()
    {
        instance = this;
        gameOver = false;
    }

    private void Update()
    {
        if (!gameOver)
        {
            currentScore += Time.deltaTime * 5;
            UpdateScore();
        }
    }

    public void AddScore(float score)
    {
        currentScore += score;
    }

    public int GetScore()
    {
        return Mathf.RoundToInt(currentScore);
    }

    void UpdateScore()
    {
        scoreText.text = Mathf.RoundToInt(currentScore).ToString();
    }

    public void GameOver()
    {
        gameOver = true;
    }
}