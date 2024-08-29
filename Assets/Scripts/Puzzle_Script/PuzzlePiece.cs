using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class PuzzlePiece : MonoBehaviour
{
    // Reference to the PuzzleManager that this piece is linked to
    [SerializeField] private PuzzleManager linkedPuzzleManager;
    // The transform of the correct puzzle piece, used to check if the correct piece is snapped in place
    [SerializeField] private Transform correctPuzzlePiece;
    // Reference to the XRSocketInteractor component attached to this GameObject
    private XRSocketInteractor socket;
    // Called when the script instance is being loaded
    private void Awake()
    {
        // Get the XRSocketInteractor component attached to this GameObject
        socket = GetComponent<XRSocketInteractor>();
    }
    // Called when the GameObject becomes enabled and active
    private void OnEnable()
    {
        // Subscribe to the selectEntered event to detect when an object is snapped into the socket
        socket.selectEntered.AddListener(ObjectSnapped);
        // Subscribe to the selectExited event to detect when an object is removed from the socket
        socket.selectExited.AddListener(ObjectRemoved);
    }
    // Called when an object is snapped into the socket
    private void ObjectSnapped(SelectEnterEventArgs selectEnterEventArgs)
    {
        // Get the interactable object that was snapped in
        var snappedObjectName = selectEnterEventArgs.interactableObject;
        // Check if the snapped object's name matches the correct puzzle piece's name
        if (snappedObjectName.transform.name == correctPuzzlePiece.name)
        {
            // Notify the PuzzleManager that a puzzle task is completed
            linkedPuzzleManager.CompletedPuzzleTask();
        }

    }
    // Called when an object is removed from the socket
    private void ObjectRemoved(SelectExitEventArgs selectExitEventArgs)
    {
        // Get the interactable object that was removed
        var removedObjectName = selectExitEventArgs.interactableObject;
        // Check if the removed object's name matches the correct puzzle piece's name
        if (removedObjectName.transform.name == correctPuzzlePiece.name)
        {
            // Notify the PuzzleManager that a puzzle task has been reversed
            linkedPuzzleManager.PuzzlePeiceRemoved();
        }
    }

  
}
