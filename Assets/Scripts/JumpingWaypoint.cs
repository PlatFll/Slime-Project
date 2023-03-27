using UnityEngine;

public class JumpingWaypoint : MonoBehaviour
{
    public float jumpForce = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}

