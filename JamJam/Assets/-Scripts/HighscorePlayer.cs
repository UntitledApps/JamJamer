using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

public class HighscorePlayer : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;


    private float characterPositionY; // Variable to store the character's Y position
    private float unitsMoved; // Variable to count the number of units moved

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
            unitsMoved += 0.24f;

            // Output the updated count (you can replace this with any other logic)
            scoreText.text = (math.round(unitsMoved)).ToString() + "m";
        }
    }
}