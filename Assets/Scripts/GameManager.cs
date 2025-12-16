using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Düþman prefabý (Madde 1)

    // Madde 8: Arrays (Doðma noktalarýný tutan dizi)
    public Transform[] spawnPoints;

    public float spawnInterval = 2f;
    private float timer;

    void Update()
    {
        // Basit zamanlayýcý
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

        // Madde 4: Instantiate (Düþmaný sahnede oluþtur)
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}