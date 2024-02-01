using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscorePlayer : MonoBehaviour
{
    
    
private  int score = 0;
[SerializeField] private TMP_Text scoreText;


private float characterPositionY; // Variable to store the character's Y position
private int unitsMoved; // Variable to count the number of units moved

void Start()
{
    // Initialize variables as needed
    characterPositionY = transform.position.y;
    unitsMoved = 0;
}

void Update()
{
    // Check if the character has moved up by one unit
    if (transform.position.y > characterPositionY)
    {
        // Update the character's Y position
        characterPositionY = transform.position.y;

        // Increase the units moved
        unitsMoved++;

        // Output the updated count (you can replace this with any other logic)
        scoreText.text = unitsMoved.ToString() + "m";
    }
}
}
