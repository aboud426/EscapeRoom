using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameControl : MonoBehaviour
{
    

// Enum to represent the different possible game states
public enum GameState
    {
        Play,  // The game is currently being played
        Win,   // The player has won the game
    }

    [Header("Winning Events")]
    // UnityEvent to be invoked when the player wins the game
    public UnityEvent onGameWinning;

    // Variable to store the current state of the game
    private GameState tempState;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the game state to Play when the game starts
        tempState = GameState.Play;
        
    }

 
    // Update is called once per frame
    void Update()
    {
        // Check if the game-winning condition has been met
        CheckForGameWinning();
    }

    // Method to set the game state to Win
    public void Win()
    {
        // Change the game state to Win
        tempState = GameState.Win;
    }

    // Method to check if the game state is set to Win
    private void CheckForGameWinning()
    {
        // If the game state is Win, invoke the onGameWinning event
        if (tempState == GameState.Win)
        {
            onGameWinning.Invoke();
        }
    }

    // Method to get the current game state
    public GameState GetGameState()
    {
        // Return the current game state
        return tempState;
    }
    
}
