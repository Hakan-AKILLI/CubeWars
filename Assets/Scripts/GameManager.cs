using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Düþman prefabý 
    public Transform[] spawnPoints;

    public float spawnInterval = 2f;
    private float timer;

    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    void SpawnEnemy()
    {
        // Rastgele bir spawn noktasý seç
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Instantiate Düþmaný sahnede oluþtrr
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}