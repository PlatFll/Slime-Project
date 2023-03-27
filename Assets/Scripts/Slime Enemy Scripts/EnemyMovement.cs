using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    //Testing KnockBack stuff
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;
    public Rigidbody2D rb;


    // Update is called once per frame
    void Update()
    {
        if(KBCounter <= 0)
        {

            if(isChasing)
            {
                //If the player is on the enemy's LEFT.
                if(transform.position.x > playerTransform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                }

                //If the player is on the enemy's RIGHT.
                if(transform.position.x < playerTransform.position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                }
            }

            else
            {
                //Check if the player is close enough to start chasing.
                if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
                {
                    isChasing = true;
                }

                if(Vector2.Distance(transform.position, playerTransform.position) > 1f) 
                {
                    isChasing = false;
                }

                //This is the movement script between destinations.
                if(patrolDestination == 0)
                {
                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                    if(Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
                    {
                        transform.localScale = new Vector3(-1, 1, 1);
                        patrolDestination = 1;
                    }
                }

                if(patrolDestination == 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                    if(Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                        patrolDestination = 0;
                    }
                }
            }
        }

        else
        {
            if(KnockFromRight)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }

            if(!KnockFromRight)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }
    }
}
