
using System;
using UnityEngine;
using UnityEngine.Events;
public class PuzzleManager : MonoBehaviour
{
    // The total number of tasks that need to be completed to solve the puzzle
    [SerializeField] private int nuberOfTasksToComplete;
    // Tracks the number of tasks that have been completed so far
    [SerializeField] private int currentlyCompletedTasks = 0;
    // Events to be triggered when the puzzle is completed
    [Header("Completion Events")]
    public UnityEvent onPuzzleCompletion;
   
    // This method is called when a puzzle task is completed
    public void CompletedPuzzleTask()
    {
        // Increment the count of completed tasks
        currentlyCompletedTasks++;

        // Check if all tasks are completed
        CheckForPuzzleCompletion();
    }

    // Checks if the puzzle has been completed
    private void CheckForPuzzleCompletion()
    {
        // If the number of completed tasks is greater than or equal to the total required tasks
        if (currentlyCompletedTasks >= nuberOfTasksToComplete)
        {
            // Trigger the completion event
            onPuzzleCompletion.Invoke();
        }
    }
    // This method is called when a puzzle piece is removed, decrementing the completed task count
    public void PuzzlePeiceRemoved()
    {
        currentlyCompletedTasks--;
    }
}
