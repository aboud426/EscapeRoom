using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    // The countdown time in seconds
    [SerializeField] private float timeRemaining = 60f;

    // Array of TextMeshPro components to display the timer in 3D space
    [SerializeField] private TextMeshPro[] timerTexts3D;

    // Boolean to track if the timer is running
    private bool timerIsRunning = false;

    // Boolean to track if the timer text is flashing
    private bool timerFlashing = false;

    // Frequency of the light and timer flash in seconds
    [SerializeField] private float flashFrequency = 1f;

    // Boolean to check if the timer is frozen
    private bool isTimerFrozen;

    // Start is called before the first frame update
    private void Start()
    {
        // Start the timer
        timerIsRunning = true;
    }

    // Update is called once per frame
    private void Update()
    {
        // If the timer is running and not frozen
        if (timerIsRunning && !isTimerFrozen)
        {
            // If there is still time remaining
            if (timeRemaining > 0)
            {
                // Decrease the remaining time
                timeRemaining -= Time.deltaTime;

                // Update the timer display
                UpdateTimerDisplay(timeRemaining);

                // If time is under 10 seconds, start flashing the timer
                if (timeRemaining <= 10f)
                {
                    // Start flashing if not already flashing
                    if (!timerFlashing)
                    {
                        StartCoroutine(FlashTimer());
                        timerFlashing = true;  // Ensure flashing only starts once
                    }
                }
            }
            else
            {
                // Stop the timer if time runs out
                timerIsRunning = false;

                // Stop all coroutines to stop flashing effects
                StopAllCoroutines();

                // Call the method to end the game
                EndGame();
            }
        }
    }

    // Coroutine to handle flashing of the timer
    private IEnumerator FlashTimer()
    {
        bool isRed = false;

        // Continuously flash the timer text
        while (true)
        {
            // Set the color to red or white
            Color colorToSet = isRed ? Color.red : Color.white;

            // Apply the color to each timer text
            foreach (var timerText in timerTexts3D)
            {
                timerText.color = colorToSet;
            }

            // Toggle the color for the next flash
            isRed = !isRed;

            // Wait for the next flash, flashing twice as fast as the specified frequency
            yield return new WaitForSeconds(flashFrequency / 2);
        }
    }

    // Method to handle the end of the game
    private void EndGame()
    {
        Debug.Log("Game Over! Time has run out.");

        // Load the Game Over scene
        SceneManager.LoadScene("GameOverScene");
    }

    // Method to freeze the timer
    public void FreezeTimer()
    {
        isTimerFrozen = true;
    }

    // Method to update the timer display
    private void UpdateTimerDisplay(float timeToDisplay)
    {
        // Add one second to show a rounded countdown (optional)
        timeToDisplay += 1;

        // Calculate minutes and seconds from the remaining time
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Format the time as a string
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Update each 3D TextMeshPro text with the formatted time
        foreach (var timerText in timerTexts3D)
        {
            if (timerText != null)
            {
                timerText.text = timeString;
            }
        }
    }
}
