using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // PC i�in mouse kontrol�
        if (Input.GetMouseButton(0)) // Mouse bas�l� tutuldu�unda
        {
            float screenHalf = Screen.width / 2f;
            Vector3 mousePos = Input.mousePosition;

            if (mousePos.x > screenHalf)
            {
                // Sa�a git
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
            else
            {
                // Sola git
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
        }
        else
        {
            // Mouse bas�l� de�ilse yatay hareketi durdur
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Mobil i�in dokunma kontrol�
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float screenHalf = Screen.width / 2f;

            if (touch.position.x > screenHalf)
            {
                // Sa�a git
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
            else
            {
                // Sola git
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Debug.Log("Coin collected!");
            GameManager.Instance.AddScore(10);
            Destroy(collision.gameObject);
        }
    }
}
