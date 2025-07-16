using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject); // 화면 밖으로 나가면 총알 삭제
    }
}
