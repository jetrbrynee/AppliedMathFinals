using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms = 20;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    public float platformHorizontalMovementRange = 2f;
    public float platformMovementFrequency = 1f;

    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);

            
            PlatformMover mover = platform.AddComponent<PlatformMover>();
            mover.range = platformHorizontalMovementRange;
            mover.frequency = platformMovementFrequency;
        }
    }
}
