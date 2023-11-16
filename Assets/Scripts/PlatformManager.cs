using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public float spawnRate = 1f;
    public float platformLifetime = 10f;
    public float minY = 1f;
    public float maxY = 3f;
    public float minX = -2.5f;
    public float maxX = 2.5f;

    private Transform playerTransform;
    private float nextSpawnTime;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        nextSpawnTime = Time.time;
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnPlatform();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnPlatform()
    {
        float spawnY = playerTransform.position.y + (maxY + Random.Range(minY, maxY));
        float spawnX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

        GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        Destroy(platform, platformLifetime);
    }
}
