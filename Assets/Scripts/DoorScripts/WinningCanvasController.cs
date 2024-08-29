using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinningCanvasController : MonoBehaviour
{
    // Reference to the Canvas GameObject that will be managed by this script
    [SerializeField] private GameObject Canvas;


    // Start is called before the first frame update
    public void Start()
    {
        // Initially deactivate the Canvas GameObject so it is not visible at the start
        Canvas.SetActive(false);
    }

    // Method to activate the canvas 
    public void PlayWhenWin()
    {
        // Activate the Canvas GameObject, making it visible
        Canvas.SetActive(true);
        
    }
}
