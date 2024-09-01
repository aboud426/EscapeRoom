using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public abstract class BasePuzzlePiece<T> : MonoBehaviour where T : BasePuzzlePiece<T>
{
    [SerializeField] protected Transform correctPuzzlePiece;

    public static event Action<T> OnPuzzlePiecePlaced;
    public static event Action<T> OnPuzzlePieceRemoved;

    private XRSocketInteractor socket;

    protected virtual void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    protected virtual void OnEnable()
    {
        socket.selectEntered.AddListener(ObjectSnapped);
        socket.selectExited.AddListener(ObjectRemoved);
    }

    protected virtual void OnDisable()
    {
        socket.selectEntered.RemoveListener(ObjectSnapped);
        socket.selectExited.RemoveListener(ObjectRemoved);
    }

    private void ObjectSnapped(SelectEnterEventArgs selectEnterEventArgs)
    {
        if (selectEnterEventArgs.interactableObject.transform.name == correctPuzzlePiece.name)
        {
            OnPuzzlePiecePlaced?.Invoke((T)this);
        }
    }

    private void ObjectRemoved(SelectExitEventArgs selectExitEventArgs)
    {
        if (selectExitEventArgs.interactableObject.transform.name == correctPuzzlePiece.name)
        {
            OnPuzzlePieceRemoved?.Invoke((T)this);
        }
    }
}
