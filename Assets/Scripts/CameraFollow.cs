using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ����ٴ� ��� (�÷��̾�)
    public Vector3 offset;   // ī�޶� ��ġ ����

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
