using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 60f; // Default value
    [SerializeField] private TextMeshPro[] timerTexts3D;
    [SerializeField] private float flashFrequency = 1f; // Default value

    private bool timerIsRunning = false;
    private bool timerFlashing = false;
    private bool isTimerFrozen = false;

    private void Start()
    {
        LoadConfig();
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning && !isTimerFrozen)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);

                if (timeRemaining <= 10f)
                {
                    if (!timerFlashing)
                    {
                        StartCoroutine(FlashTimer());
                        timerFlashing = true;
                    }
                }
            }
            else
            {
                EndGame();
            }
        }
    }

    private IEnumerator FlashTimer()
    {
        bool isRed = false;

        while (true)
        {
            Color colorToSet = isRed ? Color.red : Color.white;

            foreach (var timerText in timerTexts3D)
            {
                if (timerText != null)
                {
                    timerText.color = colorToSet;
                }
            }

            isRed = !isRed;

            yield return new WaitForSeconds(flashFrequency / 2);
        }
    }

    private void EndGame()
    {
        timerIsRunning = false;
        StopAllCoroutines();
        SceneManager.LoadScene("GameOverScene");
    }

    public void FreezeTimer()
    {
        isTimerFrozen = true;
    }

    public void UnfreezeTimer()
    {
        isTimerFrozen = false;
    }

    public void ResetTimer()
    {
        timeRemaining = 60f; // Default or configurable value
        timerIsRunning = true;
    }

    private void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(timeToDisplay, 0);

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        foreach (var timerText in timerTexts3D)
        {
            if (timerText != null)
            {
                timerText.text = timeString;
            }
        }
    }

    private void LoadConfig()
    {
        TextAsset textFile = Resources.Load<TextAsset>("timerConfig");

        if (textFile != null)
        {
            string[] lines = textFile.text.Split('\n');
            Dictionary<string, float> configValues = new();

            foreach (string line in lines)
            {
                string[] parts = line.Split('=');
                if (parts.Length == 2)
                {
                    string key = parts[0].Trim();

                    if (float.TryParse(parts[1].Trim(), out float value))
                    {
                        configValues[key] = value;
                    }
                    else
                    {
                        Debug.LogWarning("Failed to parse value for key: " + key);
                    }
                }
            }

            if (configValues.TryGetValue("countdownTime", out float countdownTime))
            {
                timeRemaining = countdownTime;
            }

            if (configValues.TryGetValue("flashFrequency", out float frequency))
            {
                flashFrequency = frequency;
            }
        }
        else
        {
            Debug.LogError("Failed to load config file.");
        }
    }
}
