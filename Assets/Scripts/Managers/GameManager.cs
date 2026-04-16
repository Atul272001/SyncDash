using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CameraShake cameraShake;

    int lives;

    private void Awake()
    {
        lives = 0;
        instance = this;
    }

    public void GameOver()
    {
        if (lives <= 3)
        {
            lives++;
            return;
        }
        UiManager.instance.GameOver();
        ScoreManager.instance.GameOver();
        Time.timeScale = 0f;
        cameraShake.ResetCamera();
    }
}
