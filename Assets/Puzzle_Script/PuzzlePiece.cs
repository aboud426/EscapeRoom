using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private PuzzleManager linkedPuzzleManager;
    [SerializeField] private Transform correctPuzzlePiece;
    private XRSocketInteractor socket;

    private void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        socket.selectEntered.AddListener(ObjectSnapped);
        socket.selectExited.AddListener(ObjectRemoved);
    }

    private void ObjectSnapped(SelectEnterEventArgs selectEnterEventArgs)
    {
        var snappedObjectName = selectEnterEventArgs.interactableObject;
        if (snappedObjectName.transform.name == correctPuzzlePiece.name)
        {
            linkedPuzzleManager.CompletedPuzzleTask();
        }

    }
    private void ObjectRemoved(SelectExitEventArgs selectExitEventArgs)
    {
        var removedObjectName = selectExitEventArgs.interactableObject;
        if (removedObjectName.transform.name == correctPuzzlePiece.name)
        {
            linkedPuzzleManager.PuzzlePeiceRemoved();
        }
    }

  
}
