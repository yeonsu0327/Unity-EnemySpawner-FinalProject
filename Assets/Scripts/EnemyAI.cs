using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player; // �÷��̾� ��ġ
    public float speed = 3f; // �� �̵� �ӵ�

    void Start()
    {
        // "Player" �±װ� ���� ������Ʈ�� ã�Ƽ� ����
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player ������Ʈ�� ã�� �� �����ϴ�! 'Player' �±׸� Ȯ���ϼ���.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // �÷��̾ ���� �̵�
            Vector3 direction = player.position - transform.position;
            direction.y = 0; // ���� ����
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
