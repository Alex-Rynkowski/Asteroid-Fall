using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    [Header("Assign Asteroid prefabs here")]
    [SerializeField] GameObject AsteroidSmall = null;
    [SerializeField] GameObject AsteroidMedium = null;
    [SerializeField] GameObject AsteroidLarge = null;

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
        

        //ToDo if Time: Pretty this up and run asteroid[i] in stead?
        int asteroidToSpawn = UnityEngine.Random.Range(1, 4);

        //ToDo: Make asteroidPosition depend on -cameraMaxX and +cameraMaxX in stead of playspace-dependent
        Vector3 asteroidPosition = new Vector2(Random.Range(-xSpawnDistance, xSpawnDistance), gameObject.transform.position.y);
        switch (asteroidToSpawn)
        {
            case 1:
                Instantiate(AsteroidSmall , asteroidPosition, Quaternion.identity);
                //Debug.Log("Now spawning" + asteroidToSpawn);
                break;
            case 2:
                Instantiate(AsteroidMedium, asteroidPosition, Quaternion.identity);
                //Debug.Log("Now spawning" + asteroidToSpawn);
                break;
            case 3:
                Instantiate(AsteroidLarge, asteroidPosition, Quaternion.identity);
                //Debug.Log("Now spawning" + asteroidToSpawn);
                break;
            default:
                //Debug.Log("Nothing to spawn");
                break;
        }
    }
}
