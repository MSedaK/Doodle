using UnityEngine;
using Terresquall;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    public Terresquall.VirtualJoystick joystick;
    private Camera mainCamera;  // Ana kameray� referans olarak tutaca��z

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;  // Ana kameray� al
    }

    void Update()
    {
        float moveInput = joystick.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Ekran wrap kontrol�
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0)
        {
            // Sol taraftan ��k�nca sa� tarafa ���nla
            Vector3 newPos = transform.position;
            newPos.x = mainCamera.ViewportToWorldPoint(new Vector3(1, viewPos.y, viewPos.z)).x;
            transform.position = newPos;
        }
        else if (viewPos.x > 1)
        {
            // Sa� taraftan ��k�nca sol tarafa ���nla
            Vector3 newPos = transform.position;
            newPos.x = mainCamera.ViewportToWorldPoint(new Vector3(0, viewPos.y, viewPos.z)).x;
            transform.position = newPos;
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
