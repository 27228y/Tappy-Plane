using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float cooldown = 1.5f;
    public List<GameObject> prefabs;

    private float lastSpawnTime;

    void Start()
    {
        GameObject randPrefab = prefabs[Random.Range(0, prefabs.Count)];

        Instantiate(randPrefab);
    }

    void Update()
    {
        if (Time.time - lastSpawnTime > cooldown)
        {
            lastSpawnTime = Time.time;
            GameObject randPrefab = prefabs[Random.Range(0, prefabs.Count)];
            Instantiate(randPrefab);
        }
    }
}
