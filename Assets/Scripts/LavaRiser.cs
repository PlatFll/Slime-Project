using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRiser : MonoBehaviour
{
    // Speed at which the lava rises
    [SerializeField] public float riseSpeed = 1f;
    [SerializeField] public float startFollowDistance = 20f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        // Check if the player has moved up far enough
        if (target.position.y > startFollowDistance)
        {
            // Get the player's position
            GameObject player = GameObject.FindWithTag("Player");
            float playerY = player.transform.position.y;

            // Calculate the new position for the lava
            float newY = Mathf.Lerp(transform.position.y, playerY, riseSpeed * Time.deltaTime);

            // Update the position of the lava
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}
