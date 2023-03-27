using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSlime : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(rigidbody2D.velocity.y < 0)
        {
            rigidbody2D.gravityScale = 15f;
        }
        if(rigidbody2D.velocity.y >= 0)
        {
            rigidbody2D.gravityScale = 8f;
        }
    }
}

