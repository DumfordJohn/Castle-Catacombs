using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> spawnPoints;
    private Dictionary<Transform, bool> spawnCooldowns = new Dictionary<Transform, bool>();

    void Start()
    {
        // Initialize the spawn cooldown dictionary with all spawn points set to available
        foreach (Transform point in spawnPoints)
        {
            spawnCooldowns[point] = false;
        }

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Iterate through each spawn point
            foreach (Transform point in spawnPoints)
            {
                // Check if the spawn point is available
                if (!spawnCooldowns[point])
                {
                    // Spawn a new enemy at this location
                    GameObject newEnemy = Instantiate(enemyPrefab, point.position, Quaternion.identity);

                    // Set the spawn point to unavailable
                    spawnCooldowns[point] = true;

                    // Wait for the enemy to die before making the spawn point available again
                    yield return new WaitUntil(() => newEnemy == null);

                    // Set the spawn point to available again
                    spawnCooldowns[point] = false;
                }
            }

            yield return new WaitForSeconds(1f); // Wait for 1 second before checking again
        }
    }
}
