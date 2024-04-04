using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] foodPrefabs; // Array of food prefabs
    [SerializeField] float spawnInterval = 5f; // Time between each spawn

    [SerializeField] float spawnAreaSize;

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
        float spawnX = Random.Range(transform.position.x - spawnAreaSize, transform.position.x + spawnAreaSize);
        float spawnY = Random.Range(transform.position.y - spawnAreaSize, transform.position.y + spawnAreaSize);
        float spawnZ = Random.Range(transform.position.z - spawnAreaSize, transform.position.z + spawnAreaSize);
        Vector3 spawnPosition = new Vector3(spawnX, transform.position.y, spawnZ);

        // Select a random food prefab
        int prefabIndex = Random.Range(0, foodPrefabs.Length);
        GameObject selectedPrefab = foodPrefabs[prefabIndex];

        // Instantiate the selected food prefab at the random position
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}

