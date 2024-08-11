
using System;
using UnityEngine;
using UnityEngine.Events;
public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private int nuberOfTasksToComplete;
    [SerializeField] private int currentlyCompletedTasks = 0;
    [Header("Completion Events")]
    public UnityEvent onPuzzleCompletion;

    public void CompletedPuzzleTask()
    {
        currentlyCompletedTasks++;
        checkForPuzzleCompletion();
    }

    private void checkForPuzzleCompletion()
    {
        if(currentlyCompletedTasks >= nuberOfTasksToComplete)
        {
            onPuzzleCompletion.Invoke();
        }
    }

    public void PuzzlePeiceRemoved()
    {
        currentlyCompletedTasks--;
    }
}
