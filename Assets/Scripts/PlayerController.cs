using UnityEngine;
using Terresquall; // Virtual Joystick namespace

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;          // Hareket hýzý
    public Rigidbody2D rb;                // Rigidbody2D bileþeni
    public Terresquall.VirtualJoystick joystick; // Joystick referansý

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Joystick'ten yatay eksende hareket girdisini al
        float moveInput = joystick.GetAxis("Horizontal");

        // Hareket hýzýný hesapla
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}
