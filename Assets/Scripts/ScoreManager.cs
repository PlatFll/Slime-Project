using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Reference to the player's transform
    //public Transform player;

    // Reference to the platform generator's highest point
    //public PlatformGenerator platformGenerator;

    // Reference to the text UI element that displays the score
    public TMP_Text scoreText;

    // The player's current score
    private int score = 0;

    // Update is called once per frame
    void Update()
    {
        // Update the score text
        scoreText.text = " " + score;
    }

    public void UpdateScore()
    {
        // Increment the score
        score++;
    }
}

