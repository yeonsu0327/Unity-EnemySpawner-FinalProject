using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootForce = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� Ŭ��
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

            // �÷��̾�� �Ѿ� ���� �浹 ��Ȱ��ȭ
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
