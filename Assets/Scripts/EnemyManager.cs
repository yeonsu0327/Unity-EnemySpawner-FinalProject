using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    private int[] respawnCounts;
    private int deadEnemies = 0;
    private int points = 0;
    private int totalEnemies = 70;
    private UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        respawnCounts = new int[enemyPrefabs.Length];

        if (uiManager != null)
        {
            uiManager.ShowGameStartText(); // 게임 스타트 텍스트 표시
        }

        for (int i = 0; i < Mathf.Min(enemyPrefabs.Length, spawnPoints.Length); i++)
        {
            SpawnEnemy(i);
        }

        UpdateEnemyCountUI();
    }

    void SpawnEnemy(int index)
    {
        if (index < 0 || index >= enemyPrefabs.Length) return;

        GameObject enemy = Instantiate(enemyPrefabs[index], spawnPoints[index].position, Quaternion.identity);
        EnemyHealth health = enemy.GetComponent<EnemyHealth>();
        health.manager = this;
        health.spawnPosition = spawnPoints[index].position;
        health.enemyTypeIndex = index;
    }

    public void RespawnEnemy(EnemyHealth enemy)
    {
        int index = enemy.enemyTypeIndex;

        if (respawnCounts[index] < 10)
        {
            respawnCounts[index]++;
            Debug.Log($"Enemy type {index} respawn count: {respawnCounts[index]}");
            enemy.ResetHealth();
        }
        else
        {
            Debug.Log($"Enemy type {index} has reached maximum respawn limit.");
            CheckGameClear();
            return;
        }

        UpdateEnemyCountUI();
    }

    public void EnemyKilled(EnemyHealth enemy)
    {
        deadEnemies++;
        points += 10;
        uiManager.UpdateDeadCount(deadEnemies);
        uiManager.UpdatePoints(points);

        RespawnEnemy(enemy);
    }

    public void UpdateEnemyCountUI()
    {
        int activeEnemies = 0;
        foreach (var enemy in FindObjectsOfType<EnemyHealth>())
        {
            if (enemy.gameObject.activeSelf)
            {
                activeEnemies++;
            }
        }
        uiManager.UpdateEnemyCount(activeEnemies);
    }

    void CheckGameClear()
    {
        int activeEnemies = 0;
        foreach (var enemy in FindObjectsOfType<EnemyHealth>())
        {
            if (enemy.gameObject.activeSelf)
            {
                activeEnemies++;
            }
        }

        if (deadEnemies == totalEnemies || activeEnemies == 0)
        {
            Debug.Log("Game Clear!");
            uiManager.ShowGameClear();
        }
    }
}
