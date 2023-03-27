using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingGoblin : MonoBehaviour
{
    public Transform[] waypoints; // an array of waypoints for the enemy to move to
    public float moveSpeed = 2f; // the speed at which the enemy moves
    public float detectionRadius = 5f; // the radius at which the enemy detects the player
    public float waitTime = 2f; // the time the enemy waits before starting to move

    private int currentWaypoint = 0; // the current waypoint the enemy is moving towards
    private bool isAwake = false; // whether or not the enemy is awake
    private bool isMoving = false; // whether or not the enemy is currently moving
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // check if the player is within the detection radius
        if (Vector2.Distance(transform.position, Player.transform.position) < detectionRadius)
        {
            // if the enemy is not awake, start the waking up process
            if (!isAwake)
            {
                StartCoroutine(WakeUp());
                isAwake = true;
            }
        }

        // if the enemy is awake and not currently moving, start moving
        if (isAwake && !isMoving)
        {
            StartCoroutine(Move());
        }
    }

    // a coroutine that makes the enemy wait before starting to move
    IEnumerator WakeUp()
    {
        yield return new WaitForSeconds(waitTime);
    }

    // a coroutine that makes the enemy move towards the waypoints
    IEnumerator Move()
    {
        isMoving = true;
        while (currentWaypoint < waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.2f)
            {
                currentWaypoint++;
            }
            yield return null;
        }
        isMoving = false;
    }
}





