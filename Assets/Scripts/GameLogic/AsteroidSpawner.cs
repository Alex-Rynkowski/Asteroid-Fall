using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    [Header("!!Assign number of Asteroids here")]
    [SerializeField] GameObject[] asteroids = null;

    [Header("Spawning distance along X")]
    [SerializeField] float xSpawnDistance = 8.5f;  

    [Header("Spawn Timer in Seconds")]
    [SerializeField] private float minSpawnDelay = 0.2f;
    [SerializeField] private float maxSpawnDelay = 1.3f;
    bool shouldSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        // Tick down the spawn timer at a frame-independent rate

        while (shouldSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAsteroid();
        }
        yield return new WaitForSeconds(0.1f);
    }

    private void SpawnAsteroid()
    {
        // Determines which asteroid to spawn and at which point on X of the spawner
        int asteroidToSpawn = Random.Range(0, asteroids.Length);
        Vector3 asteroidPosition = new Vector2(Random.Range(-xSpawnDistance, xSpawnDistance), gameObject.transform.position.y);

        // Spawns the chosen Asteroid
        Instantiate(asteroids[asteroidToSpawn], asteroidPosition, Quaternion.identity);

    }
}
