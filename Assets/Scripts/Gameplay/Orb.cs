using UnityEngine;

public class Orb : MonoBehaviour, IInteractable
{
    public GameObject collectOrbFx;
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
        ScoreManager.instance.AddScore(100f);
        ObjectPooler.Instance.ResetPostion(gameObject);
    }

    void PlayVFX()
    {
        GameObject fx = Instantiate(collectOrbFx, transform.position, Quaternion.identity);
        ParticleSystem ps = fx.GetComponent<ParticleSystem>();
        ps.Play();
        Debug.Log(collectOrbFx.transform.position);
    }
}
