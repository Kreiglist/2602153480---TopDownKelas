using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton
{
    private SpawnController spawnController;

    new private void Awake()
    {
        base.Awake();
        spawnController = FindObjectOfType<SpawnController>();

        if (spawnController == null)
        {
            Debug.LogError("SpawnController not found in the scene.");
        }
    }

    private void Start()
    {
        if (spawnController != null)
        {
            // Set the player spawn position
            Vector3 playerSpawnPosition = new Vector3(1, 0, 0);
            GameObject playerSpawnPoint = new GameObject("PlayerSpawnPoint");
            playerSpawnPoint.transform.position = playerSpawnPosition;
            spawnController.Spawn("Player", 1, 0, playerSpawnPoint.transform);

            // Set the enemy spawn points
            List<Transform> enemySpawnPoints = new List<Transform>();
            enemySpawnPoints.Add(CreateSpawnPoint(new Vector3(0, 5, 0)));

            // Start endless spawning of enemies
            spawnController.SpawnEndlessly("Enemy", 5, enemySpawnPoints);
        }
    }

    private Transform CreateSpawnPoint(Vector3 position)
    {
        GameObject spawnPoint = new GameObject("SpawnPoint");
        spawnPoint.transform.position = position;
        return spawnPoint.transform;
    }
}
