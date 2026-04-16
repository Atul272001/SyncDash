using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    bool gameOver;
    float currentScore;
    float scoreIncreseTimer = 2;

    float speed = 5;

    [SerializeField] Text scoreText;

    private void Awake()
    {
        instance = this;
        gameOver = false;
    }

    private void Update()
    {
        if (scoreIncreseTimer > 0)
        {
            scoreIncreseTimer -= Time.deltaTime;
        }
        else
        {
            speed += 2f;
            speed = Mathf.Clamp(speed, 5f, 70);

            scoreIncreseTimer = 5f;
        }


        if (!gameOver)
        {
            currentScore += Time.deltaTime * speed;
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