using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public GameObject platformPrefabs;
    public int numberofPlatforms = 10;
    public float levelWidth = 3;
    public float minY = .1f;
    public float maxY = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 spawnPosition = new Vector2();

        for (int i = 0; i < numberofPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefabs, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
