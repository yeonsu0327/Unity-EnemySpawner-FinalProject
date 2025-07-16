using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootForce = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 클릭
        {
            ShootGun();
        }
    }

    void ShootGun()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            // 플레이어와 총알 간의 충돌 비활성화
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direction = (hit.point - firePoint.position).normalized;
                rb.AddForce(direction * shootForce, ForceMode.Impulse);
            }
            Destroy(bullet, 2f);
        }
    }
}
