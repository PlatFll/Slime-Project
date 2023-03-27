using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTriggerScore : MonoBehaviour
{
    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the other collider is the player
       
        if (other.tag == "Player")
        {
            // The player has passed the platform
            Debug.Log("Player passed the platform!");
            scoreManager.UpdateScore();
            gameObject.SetActive(false);
        }
        
    }
}