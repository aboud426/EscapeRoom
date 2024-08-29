using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartTheGame()
    {
        // Reset time scale in case it was paused
        Time.timeScale = 1f;
        // Load the game scene 
        SceneManager.LoadScene("Main VR Scene");
    }
}
