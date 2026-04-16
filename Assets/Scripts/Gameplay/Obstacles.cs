using UnityEngine;

public class Obstacles : MonoBehaviour, IInteractable
{
    Transform player;
    float disableDistance = 10;

    private void Update()
    {
        if(player == null)
            return;
        if (transform.position.z < player.position.z - disableDistance)
        {
            ObjectPooler.Instance.ResetPostion(gameObject);
        }
    }

    public void GetPlayerTransform(Transform playerTransform)
    {
        player = playerTransform;
    }

    public void OnInteract()
    {
        PlayVFX();
        ObjectPooler.Instance.ResetPostion(gameObject);
        if (PlayerPrefs.GetInt("HighScore") < ScoreManager.instance.GetScore())
        {
            PlayerPrefs.SetInt("HighScore", ScoreManager.instance.GetScore());
        }
        GameManager.instance.GameOver();
    }

    void PlayVFX()
    {
        GameManager.instance.cameraShake.ShakeCamera(0.2f, 0.2f);
    }
}
