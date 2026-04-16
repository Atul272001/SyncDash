using UnityEngine;

public class Floor : MonoBehaviour
{
    Transform player;
    float disableDistance = 15f;

    private void Update()
    {
        if (player == null)
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
}
