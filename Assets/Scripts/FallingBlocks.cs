using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlocks : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public float maxTimeToSpawn = 0.5f, minTimeToSpawn = 0.1f, timeToSpawnRandomness = 0.1f, angleLimit = 15f;
    private float timeOfSpawn, newTimeToSpawn;
    private float screenWidth, screenHeight, halfBlockHeight;

    // Start is called before the first frame update
    void Start()
    {
        timeOfSpawn = Time.time;
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize;
        screenHeight = Camera.main.orthographicSize;
        halfBlockHeight = fallingBlockPrefab.transform.localScale.x / 2;
        newTimeToSpawn = minTimeToSpawn + Random.Range(-timeToSpawnRandomness, timeToSpawnRandomness);
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeOfSpawn > newTimeToSpawn)
        {
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(-angleLimit, angleLimit));
            Vector2 spawnPosition = new Vector2(Random.Range(-screenWidth, screenWidth), screenHeight + halfBlockHeight);
            Instantiate(fallingBlockPrefab, spawnPosition, spawnRotation);

            timeOfSpawn = Time.time;
            newTimeToSpawn = Mathf.Lerp(maxTimeToSpawn, minTimeToSpawn, Difficulty.getDifficulty()) + Random.Range(-timeToSpawnRandomness, timeToSpawnRandomness);

        }
    }
}
