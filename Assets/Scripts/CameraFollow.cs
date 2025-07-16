using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 따라다닐 대상 (플레이어)
    public Vector3 offset;   // 카메라 위치 보정

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
