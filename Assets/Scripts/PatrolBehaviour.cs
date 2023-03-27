using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;

    Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if(IsFacingRight())
        {
            //Move right
            myRigidbody.velocity = new Vector2(movementSpeed, 0f);

        }
        else
        {
            //Move left
            myRigidbody.velocity = new Vector2(-movementSpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Turn
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

    }

}




















    /*public float movementSpeed;

    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;


    private void Update()
    {
        transform.Translate(Time.deltaTime * movementSpeed * transform.right);

        if(!Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer))
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        movementSpeed *= -1;
    }*/

