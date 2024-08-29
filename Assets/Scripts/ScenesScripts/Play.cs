using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void PlayTheGame()
    {
        // Load the Main VR Scene
        SceneManager.LoadScene("Main VR Scene");
    }
}
