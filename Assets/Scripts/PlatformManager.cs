using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public float spawnRate = 2f;
    public float platformLifetime = 20f;
    public float minY = 0.5f; //Minimum vertical space above the camera where platforms can spawn
    public float maxY = 1.5f; //Maximum vertical space above the camera where platforms can spawn
    public float safeZone = 1.5f; //Horizontal padding from the edges of the camera view

    private Transform playerTransform;
    private Camera mainCamera;
    private float nextSpawnTime;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamera = Camera.main; 
        nextSpawnTime = Time.time + spawnRate;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnPlatform();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnPlatform()
    {
        // Calculate the visible bounds of the camera
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        Vector2 cameraBoundsMin = (Vector2)mainCamera.transform.position - new Vector2(cameraWidth, cameraHeight) * 0.5f;
        Vector2 cameraBoundsMax = (Vector2)mainCamera.transform.position + new Vector2(cameraWidth, cameraHeight) * 0.5f;

        // Pang sure na yung spawn Y is always above the camera view
        float spawnY = cameraBoundsMax.y + Random.Range(minY, maxY);

        // Pang sure na yung spawn X is always above the camera view
        float spawnX = Random.Range(cameraBoundsMin.x + safeZone, cameraBoundsMax.x - safeZone);

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
        GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        Destroy(platform, platformLifetime);
    }
}
