using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 15f; // 10'dan 15'e çýkardýk, daha yükseðe zýplayacak

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
}