using UnityEngine;

public class ObjectSpawnner : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float spawnDistance = 100f;
    [SerializeField] float spawnSpacing = 300f;
    [SerializeField] float lastSpawnZ = 0f;
    [SerializeField] float height = 0.5f;

    // if the orb didn't spawn during the spawn funciton call. and increase the count and if it reaches a certain number then forcly spawn he orb and reset the count
    int orbSpawnCountDown;

    private void Update()
    {
        if (player.position.z + spawnDistance > lastSpawnZ)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        lastSpawnZ += spawnSpacing;
        Vector3 floorSpawnPos = new Vector3(0, 0, lastSpawnZ);
        GameObject floor = ObjectPooler.Instance.GetFloor();
        floor.transform.position = floorSpawnPos;
        floor.GetComponent<Floor>().GetPlayerTransform(player);
        floor.SetActive(true);

        Vector3 ghostGloorSpawnPos = new Vector3(-22, 0, lastSpawnZ);
        GameObject ghostFloor = ObjectPooler.Instance.GetFloor();
        ghostFloor.transform.position = ghostGloorSpawnPos;
        ghostFloor.GetComponent<Floor>().GetPlayerTransform(player);
        ghostFloor.SetActive(true);


        Vector3 spawnPos = new Vector3(0, height, lastSpawnZ);
        GameObject obstacle = ObjectPooler.Instance.GetObstacles();
        obstacle.transform.position = spawnPos;
        obstacle.GetComponent<Obstacles>().GetPlayerTransform(player);
        obstacle.SetActive(true);

        float chance = Random.Range(0f, 1f);

        if (chance < 0.5f || orbSpawnCountDown > 3)
        {
            orbSpawnCountDown = 0;
            GameObject orb = ObjectPooler.Instance.GetOrb();
            orb.transform.position = spawnPos + (Vector3.up * 2f);
            orb.GetComponent<Orb>().GetPlayerTransform(player);
            orb.SetActive(true);
        }
        else
        {
            orbSpawnCountDown++;
        }
        
    }

}
