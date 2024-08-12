using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 60f;  // The countdown time in seconds
    [SerializeField] private TextMeshPro timerText3D;  // Reference to the TextMeshPro component
    private bool timerIsRunning = false;
    //private bool lightFlashing = false;  // To track if the lights are flashing
    private bool timerFlashing = false;  // To track if the timer text is flashing

    [SerializeField] private float flashFrequency = 1f;   // Frequency of the light and timer flash in seconds
    //public Light[] roomLights;  // Array to store all lights in the room

    private void Start()
    {
        // Start the timer
        timerIsRunning = true;

    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);

                // Start flashing lights and timer when the timer is under 10 seconds
                if (timeRemaining <= 10f)
                {
                    if (!timerFlashing)
                    {
                        StartCoroutine(FlashTimer());
                        timerFlashing = true; // Ensure we only start the timer flashing once
                    }
                }
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                StopAllCoroutines();  // Stop all coroutines to stop flashing effects
                EndGame();  // Call the method to end the game
            }
        }
    }

    private IEnumerator FlashLights()
    {
        while (true)
        {
            // Turn off all lights to make the room dark
            
            yield return new WaitForSeconds(flashFrequency);

            // Turn the lights back on
           
            yield return new WaitForSeconds(flashFrequency);
        }
    }

    private IEnumerator FlashTimer()
    {
        bool isRed = false;

        while (true)
        {
            if (isRed)
            {
                timerText3D.color = Color.white;  // Change back to the default color (white)
            }
            else
            {
                timerText3D.color = Color.red;  // Change the color to red
            }
            isRed = !isRed;  // Toggle the color
            yield return new WaitForSeconds(flashFrequency / 2);  // Flash twice as fast as the lights
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Over! Time has run out.");
        Time.timeScale = 0f;  // This will pause everything in the game
                              // Optionally, you can display a "Game Over" UI here
    }

    private void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay += 1;  // Optional: Add one second to show a rounded countdown

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Update the 3D TextMeshPro text
        if (timerText3D != null)
        {
            timerText3D.text = timeString;
        }
    }
}
