using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // The object that the camera should follow
    public Transform target;

    // The speed at which the camera should follow the target
    public float followSpeed = 5f;

    // The minimum distance that the player must move up before the camera starts following
    public float startFollowDistance = 20f;

    // Update is called once per frame
    void Update()
    {
        // Check if the player has moved up far enough
        if (target.position.y > startFollowDistance)
        {
            // Move the camera towards the target's position
            Vector3 targetPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}











































/*using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // The object that the camera should follow
    public Transform target;

    // The speed at which the camera should follow the target
    public float followSpeed = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move the camera towards the target's position
        Vector3 targetPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}*/





































/*using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);
    }
}*/
