using UnityEngine;
using UnityEngine.UI;

// Ensure the GameObject has a BoxCollider component attached
[RequireComponent(typeof(BoxCollider))]
public class KeyController : MonoBehaviour
{
    // Reference to the BoxCollider component attached to the GameObject
    private BoxCollider keyCollider;

    // Reference to the Rigidbody component attached to the GameObject (not used in this code but might be intended for future use)
    private Rigidbody keyRB;

    // Reference to the Text UI element to display messages to the player
    public Text txtToDisplay;

    // Reference to the DoorController script that handles door interactions
    public DoorController DC;

    /// <summary>
    /// Initializes the key controller by ensuring the BoxCollider is set as a trigger.
    /// </summary>
    private void Start()
    {
        // Get the BoxCollider component attached to this GameObject
        keyCollider = GetComponent<BoxCollider>();

        // Set the BoxCollider as a trigger to allow interaction with the player
        keyCollider.isTrigger = true;
    }

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this GameObject.
    /// </summary>
    /// <param name="other">The other collider that has entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Notify the DoorController that the key has been acquired
            DC.gotKey = true;

            // Display a message on the UI to indicate that the key has been acquired
            txtToDisplay.gameObject.SetActive(true);
            txtToDisplay.text = "Key Acquired";

            // Deactivate this GameObject, effectively "removing" the key from the scene
            this.gameObject.SetActive(false);
        }
    }
}
