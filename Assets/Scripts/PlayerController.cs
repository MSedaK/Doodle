using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Camera mainCamera; // Ana kamera referansý eklendi

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main; // Ana kamerayý al
    }

    void Update()
    {
        float moveDirection = 0;

        // PC için mouse kontrolü
        if (Input.GetMouseButton(0))
        {
            float screenHalf = Screen.width / 2f;
            Vector3 mousePos = Input.mousePosition;

            if (mousePos.x > screenHalf)
            {
                moveDirection = 1;
            }
            else
            {
                moveDirection = -1;
            }
        }

        // Mobil için dokunma kontrolü
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float screenHalf = Screen.width / 2f;

            if (touch.position.x > screenHalf)
            {
                moveDirection = 1;
            }
            else
            {
                moveDirection = -1;
            }
        }

        // Hareketi uygula
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Animasyon kontrolü
        animator.SetBool("isMoving", moveDirection != 0);

        // Karakterin yönünü çevir
        if (moveDirection != 0)
        {
            spriteRenderer.flipX = moveDirection < 0;
        }

        // Ekran wrap kontrolü eklendi
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0)
        {
            // Sol taraftan çýkýnca sað tarafa ýþýnla
            Vector3 newPos = transform.position;
            newPos.x = mainCamera.ViewportToWorldPoint(new Vector3(1, viewPos.y, viewPos.z)).x;
            transform.position = newPos;
        }
        else if (viewPos.x > 1)
        {
            // Sað taraftan çýkýnca sol tarafa ýþýnla
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