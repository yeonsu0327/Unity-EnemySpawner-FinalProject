using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text enemyCountText;  // 현재 남은 적의 수
    public TMP_Text deadCountText;   // 죽은 적의 수
    public TMP_Text pointsText;      // 포인트 텍스트
    public TMP_Text hpText;          // HP 텍스트
    public GameObject gameClearPanel; // 게임 클리어 UI 패널
    public GameObject gameOverPanel;  // 게임 오버 UI 패널
    public TMP_Text gameStartText;    // 게임 스타트 텍스트

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

    // 게임 스타트 텍스트 표시
    public void ShowGameStartText()
    {
        if (gameStartText != null)
        {
            Debug.Log("Displaying Game Start Text");
            gameStartText.gameObject.SetActive(true); // 텍스트 활성화
            StartCoroutine(HideGameStartText());      // 일정 시간 후 텍스트 비활성화
        }
    }

    private System.Collections.IEnumerator HideGameStartText()
    {
        yield return new WaitForSeconds(2f); // 2초 동안 텍스트 표시
        if (gameStartText != null)
        {
            Debug.Log("Hiding Game Start Text");
            gameStartText.gameObject.SetActive(false); // 텍스트 비활성화
        }
    }
}
