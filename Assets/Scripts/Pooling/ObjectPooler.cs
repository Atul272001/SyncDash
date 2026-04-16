using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance { get; private set; }
    [SerializeField] GameObject orbObject;
    [SerializeField] GameObject obstacleObject;
    [SerializeField] GameObject floorObject;

    public List<GameObject> orbs;
    public List<GameObject> obstacles;
    public List<GameObject> floors;

    [SerializeField] int spawningCount = 10;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        orbs = SpawnObjects(orbObject);
        obstacles = SpawnObjects(obstacleObject);
        floors = SpawnObjects(floorObject);
    }

    List<GameObject> SpawnObjects(GameObject gameObject)
    {
        List<GameObject> list = new List<GameObject>();
        GameObject tempGameObject;
        for (int i = 0; i < spawningCount; i++)
        {
            tempGameObject = Instantiate(gameObject);
            list.Add(tempGameObject);
            tempGameObject.SetActive(false);
        }

        return list;
    }

    public GameObject GetFloor()
    {
        return ObjectFromPool(floors);
    }

    public GameObject GetOrb()
    {
        return ObjectFromPool(orbs);
    }

    public GameObject GetObstacles()
    {
        return ObjectFromPool(obstacles);
    }

    private GameObject ObjectFromPool(List<GameObject> gameObject)
    {
        foreach (GameObject obj in gameObject)
        {
            if(!obj.activeInHierarchy)
                return obj;
        }

        GameObject newObj = Instantiate(gameObject[0]);
        newObj.SetActive(false);
        gameObject.Add(newObj);
        return newObj;
    }

    public void ResetPostion(GameObject gameObject)
    {
        gameObject.transform.position = Vector3.zero;
        gameObject.SetActive(false);
    }

}
