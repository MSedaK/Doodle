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
}
