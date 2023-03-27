using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    // the game object with the box collider
    public GameObject boxColliderObject;

    // the game object with the collider to ignore
    public GameObject ignoreColliderObject;

    void Start()
    {
        // get the box collider component
        BoxCollider2D boxCollider = boxColliderObject.GetComponent<BoxCollider2D>();

        // get the collider to ignore
        Collider2D ignoreCollider = ignoreColliderObject.GetComponent<Collider2D>();

        // ignore collisions between the box collider and the collider to ignore
        Physics2D.IgnoreCollision(boxCollider, ignoreCollider);
    }
}

