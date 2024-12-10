using UnityEngine;
using Terresquall; // Virtual Joystick namespace

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;          // Hareket h�z�
    public Rigidbody2D rb;                // Rigidbody2D bile�eni
    public Terresquall.VirtualJoystick joystick; // Joystick referans�

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Joystick'ten yatay eksende hareket girdisini al
        float moveInput = joystick.GetAxis("Horizontal");

        // Hareket h�z�n� hesapla
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // E�er �arp��an obje Coin ise
        if (collision.CompareTag("Coin"))
        {
            Debug.Log("Coin collected!");

            // GameManager �zerinden skoru art�r
            GameManager.Instance.AddScore(10);

            // Coin objesini yok et
            Destroy(collision.gameObject);
        }
    }
}
