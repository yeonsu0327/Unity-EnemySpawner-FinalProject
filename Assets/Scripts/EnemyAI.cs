using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player; // 플레이어 위치
    public float speed = 3f; // 적 이동 속도

    void Start()
    {
        // "Player" 태그가 붙은 오브젝트를 찾아서 참조
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player 오브젝트를 찾을 수 없습니다! 'Player' 태그를 확인하세요.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // 플레이어를 향해 이동
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // 높이 고정
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
