using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private UIManager uiManager;
    private int hp = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        uiManager = FindObjectOfType<UIManager>();

        if (uiManager != null)
        {
            uiManager.UpdateHP(hp); // 초기 HP 설정
        }
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ);
        rb.AddForce(movement * moveSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hp--;
            if (uiManager != null)
            {
                uiManager.UpdateHP(hp);
            }

            if (hp <= 0)
            {
                if (uiManager != null)
                {
                    uiManager.ShowGameOver();
                }
            }
        }
    }
}
