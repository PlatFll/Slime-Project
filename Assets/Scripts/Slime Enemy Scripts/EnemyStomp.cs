using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{   //THIS IS ON THE PLAYER'S FEET, IT DETECTS IF YOU STOMP THE ENEMY'S WEAKPOINT.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "WeakPoint")
        {
            Destroy(collision.gameObject);
        }
    }
}
