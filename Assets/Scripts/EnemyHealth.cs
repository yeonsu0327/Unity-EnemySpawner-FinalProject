using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1;
    public EnemyManager manager;
    public Vector3 spawnPosition;
    public int enemyTypeIndex;

    private Renderer enemyRenderer;
    private Color originalColor;

    void Start()
    {
        spawnPosition = transform.position;
        enemyRenderer = GetComponent<Renderer>();
        if (enemyRenderer != null)
        {
            originalColor = enemyRenderer.material.color;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            health--;
            Destroy(other.gameObject);

            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        if (enemyRenderer != null)
        {
            enemyRenderer.material.color = Color.black;
        }

        Invoke(nameof(DisableAndNotifyManager), 0.3f);
    }

    void DisableAndNotifyManager()
    {
        gameObject.SetActive(false);
        if (manager != null)
        {
            manager.EnemyKilled(this);
        }
    }

    public void ResetHealth()
    {
        health = 1;
        transform.position = spawnPosition;

        if (enemyRenderer != null)
        {
            enemyRenderer.material.color = Color.white;
        }

        gameObject.SetActive(true);

        // 부활 시 색상 애니메이션
        Invoke(nameof(RestoreOriginalColor), 0.5f);
    }

    void RestoreOriginalColor()
    {
        if (enemyRenderer != null)
        {
            enemyRenderer.material.color = originalColor;
        }
    }
}
