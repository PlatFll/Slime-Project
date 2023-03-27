using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBook : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireRate = 1f; // the rate at which the enemy shoots fireballs
    public float detectionRadius = 5f; // the radius at which the enemy detects the player
    public float startAngle = 0f; // the starting angle for shooting fireballs
    public float angleIncrement = 45f; // the amount to increment the shooting angle after each shot

    private float nextFireTime = 0f; // the time when the enemy can shoot another fireball
    private float currentAngle; // the current angle at which the enemy is shooting fireballs
    private GameObject player;

    void Start()
    {
        currentAngle = startAngle;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // check if the player is within the detection radius
        if (Vector2.Distance(transform.position, player.transform.position) < detectionRadius)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // check if the current time is greater than the next fire time
        if (Time.time > nextFireTime)
        {
            // instantiate a new fireball at the enemy's position
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

            // calculate the direction to shoot the fireball in
            Vector2 direction = new Vector2(Mathf.Cos(currentAngle * Mathf.Deg2Rad), Mathf.Sin(currentAngle * Mathf.Deg2Rad));

            // add the force to the fireball in the calculated direction
            fireball.GetComponent<Rigidbody2D>().AddForce((player.transform.position - transform.position).normalized * fireRate, ForceMode2D.Impulse);

            // increment the current angle for the next shot
            currentAngle += angleIncrement;

            // set the next fire time
            nextFireTime = Time.time + fireRate;
        }
    }
}




