using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class IdiomPuzzleManager : MonoBehaviour
{
    // The total number of tasks that need to be completed to solve the idiom puzzle
    [SerializeField] private int nuberOfTasksToComplete;

    // Tracks the number of tasks that have been completed so far
    [SerializeField] private int currentlyCompletedTasks = 0;

    // Events to be triggered when the idiom puzzle is completed
    [Header("Completion Events")]
    public UnityEvent onIdiomPuzzleCompletion;

    // This method is called when a task related to the idiom puzzle is completed
    public void CompletedIdiomPuzzleTask()
    {
        // Increment the count of completed tasks
        currentlyCompletedTasks++;

        // Check if all tasks are completed
        CheckForIdiomPuzzleCompletion();
    }

    // Checks if the idiom puzzle has been completed
    private void CheckForIdiomPuzzleCompletion()
    {
        // If the number of completed tasks is greater than or equal to the total required tasks
        if (currentlyCompletedTasks >= nuberOfTasksToComplete)
        {
            // Trigger the completion event
            onIdiomPuzzleCompletion.Invoke();
        }
    }

    // This method is called when a puzzle piece is removed, decrementing the completed task count
    public void PuzzlePeiceRemoved()
    {
        currentlyCompletedTasks--;
    }
}
