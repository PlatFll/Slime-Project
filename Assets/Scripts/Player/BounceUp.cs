using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceUp : MonoBehaviour
{
    // The upward force to apply to the object when it bounces
    public float bounceForce = 5f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object has hit a surface with a physics material that has bounciness
        if (collision.collider.sharedMaterial != null && collision.collider.sharedMaterial.bounciness > 0)
        {
            // Apply an upward force to the object
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, bounceForce);
        }
    }
}
