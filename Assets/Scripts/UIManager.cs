using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text enemyCountText;  // ���� ���� ���� ��
    public TMP_Text deadCountText;   // ���� ���� ��
    public TMP_Text pointsText;      // ����Ʈ �ؽ�Ʈ
    public TMP_Text hpText;          // HP �ؽ�Ʈ
    public GameObject gameClearPanel; // ���� Ŭ���� UI �г�
    public GameObject gameOverPanel;  // ���� ���� UI �г�
    public TMP_Text gameStartText;    // ���� ��ŸƮ �ؽ�Ʈ

    public void UpdateEnemyCount(int count)
    {
        if (enemyCountText != null)
        {
            enemyCountText.text = $"Enemy: {count}";
        }
    }

    public void UpdateDeadCount(int count)
    {
        if (deadCountText != null)
        {
            deadCountText.text = $"Dead Enemies: {count}";
        }
    }

    public void UpdatePoints(int points)
    {
        if (pointsText != null)
        {
            pointsText.text = $"Points: {points}";
        }
    }

    public void UpdateHP(int hp)
    {
        if (hpText != null)
        {
            hpText.text = $"HP: {hp}";
        }
    }

    public void ShowGameClear()
    {
        if (gameClearPanel != null)
        {
            gameClearPanel.SetActive(true);
        }
        Debug.Log("Game Clear!");
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        Debug.Log("Game Over!");
    }

    // ���� ��ŸƮ �ؽ�Ʈ ǥ��
    public void ShowGameStartText()
    {
        if (gameStartText != null)
        {
            Debug.Log("Displaying Game Start Text");
            gameStartText.gameObject.SetActive(true); // �ؽ�Ʈ Ȱ��ȭ
            StartCoroutine(HideGameStartText());      // ���� �ð� �� �ؽ�Ʈ ��Ȱ��ȭ
        }
    }

    private System.Collections.IEnumerator HideGameStartText()
    {
        yield return new WaitForSeconds(2f); // 2�� ���� �ؽ�Ʈ ǥ��
        if (gameStartText != null)
        {
            Debug.Log("Hiding Game Start Text");
            gameStartText.gameObject.SetActive(false); // �ؽ�Ʈ ��Ȱ��ȭ
        }
    }
}
