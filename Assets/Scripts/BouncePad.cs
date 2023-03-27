using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{

    public Rigidbody2D PlayerRB;

    // The upward force to apply to the object when it bounces
    public float bounceForce = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object has hit a surface with a physics material that has bounciness
        if (collision.collider.sharedMaterial != null)
        {
            // Apply an upward force to the object
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.y, bounceForce);
        }
    }
}
