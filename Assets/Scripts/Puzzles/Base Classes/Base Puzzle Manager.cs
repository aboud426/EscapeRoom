using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePuzzleManager<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected int numberOfTasksToComplete;
    [SerializeField] protected int currentlyCompletedTasks = 0;

    public UnityEvent onPuzzleCompletion;

    protected abstract event Action<T> OnPuzzlePiecePlaced;
    protected abstract event Action<T> OnPuzzlePieceRemoved;

    private void OnEnable()
    {
        OnPuzzlePiecePlaced += CompletedPuzzleTask;
        OnPuzzlePieceRemoved += PuzzlePieceRemoved;
    }

    private void OnDisable()
    {
        OnPuzzlePiecePlaced -= CompletedPuzzleTask;
        OnPuzzlePieceRemoved -= PuzzlePieceRemoved;
    }

    private void CompletedPuzzleTask(T piece)
    {
        currentlyCompletedTasks++;
        CheckForPuzzleCompletion();
    }

    private void PuzzlePieceRemoved(T piece)
    {
        currentlyCompletedTasks--;
    }

    private void CheckForPuzzleCompletion()
    {
        if (currentlyCompletedTasks >= numberOfTasksToComplete)
        {
            onPuzzleCompletion.Invoke();
        }
    }
}
