using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Camera mainCamera; // Ana kamera referans� eklendi

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main; // Ana kameray� al
    }

    void Update()
    {
        float moveDirection = 0;

        // PC i�in mouse kontrol�
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

        // Mobil i�in dokunma kontrol�
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

        // Animasyon kontrol�
        animator.SetBool("isMoving", moveDirection != 0);

        // Karakterin y�n�n� �evir
        if (moveDirection != 0)
        {
            spriteRenderer.flipX = moveDirection < 0;
        }

        // Ekran wrap kontrol� eklendi
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