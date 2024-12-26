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
        // PC için mouse kontrolü
        if (Input.GetMouseButton(0)) // Mouse basýlý tutulduðunda
        {
            float screenHalf = Screen.width / 2f;
            Vector3 mousePos = Input.mousePosition;

            if (mousePos.x > screenHalf)
            {
                // Saða git
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
            // Mouse basýlý deðilse yatay hareketi durdur
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Mobil için dokunma kontrolü
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float screenHalf = Screen.width / 2f;

            if (touch.position.x > screenHalf)
            {
                // Saða git
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
