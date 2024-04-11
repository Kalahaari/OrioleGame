using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs; // Array of food prefabs
    public float spawnInterval = 5f; // Time between each spawn
    public Vector3 spawnAreaMin = new Vector3(-10, 0, -10); // Minimum spawn coordinates
    public Vector3 spawnAreaMax = new Vector3(10, 0, 10); // Maximum spawn coordinates

    private float timeSinceLastSpawn;

    private void Start()
    {
        timeSinceLastSpawn = spawnInterval; // Initialize timer to spawn food immediately
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnFood();
            timeSinceLastSpawn = 0;
        }
    }

    void SpawnFood()
    {
        if (foodPrefabs.Length == 0) return; // Check if foodPrefabs array is empty

        // Generate a random position within the spawn area
        float spawnX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float spawnY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float spawnZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, spawnZ);

        // Select a random food prefab
        int prefabIndex = Random.Range(0, foodPrefabs.Length);
        GameObject selectedPrefab = foodPrefabs[prefabIndex];

        // Instantiate the selected food prefab at the random position
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}

