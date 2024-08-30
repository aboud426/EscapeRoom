using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    // Indicates if a key is required to open the door
    [SerializeField] private bool keyNeeded = false;

    // Indicates if the player has acquired the key
    public bool gotKey;

    // Reference to the GameObject representing the key
    [SerializeField] private GameObject key;

    // UnityEvent that is triggered when the zone is entered
    private UnityEvent _onZoneEntered = new();

    // Reference to the GameObject representing the department door
    [SerializeField] private GameObject _departmentDoor;

    // UnityEvent that is triggered when the door is opened
    [Header("Completion Events")]
    public UnityEvent onDoorOpened;

    // Reference to the Animator component controlling the door animations
    private Animator animator;

    // Flag to check if the door is already opened
    private bool isDoorOpend = false;

    private void OnEnable()
    {
        // Subscribe CheckDoorOpenConditions method to the _onZoneEntered event
        _onZoneEntered.AddListener(CheckDoorOpenConditions);
        // Subscribe the PlaySound method to the onBoxOpened event, so it gets called when the event is triggered
        onDoorOpened.AddListener(PlaySound);
    }

    private void OnDisable()
    {
        // Unsubscribe CheckDoorOpenConditions method from the _onZoneEntered event
        _onZoneEntered.RemoveListener(CheckDoorOpenConditions);
        // Unsubscribe the PlaySound method from the onBoxOpened event to prevent memory leaks or unexpected behavior
        onDoorOpened.RemoveListener(PlaySound);
    }

    /// <summary>
    /// Initializes the state of variables and components
    /// </summary>
    private void Start()
    {
        // Set the initial state of the gotKey variable
        gotKey = false;

        // Initialize the Animator component attached to the _departmentDoor GameObject
        animator = _departmentDoor.GetComponent<Animator>();
    }

    /// <summary>
    /// Checks if the conditions for opening the door are met
    /// </summary>
    private void CheckDoorOpenConditions()
    {
        if (keyNeeded)
        {
            // If a key is needed, check if the player has acquired it
            if (gotKey)
            {
                // Disable the door collider to allow the door to be opened
                _departmentDoor.GetComponent<Collider>().enabled = false;

                // Open the door
                OpenDoor();
            }
        }
        else
        {
            // If no key is needed, open the door directly
            OpenDoor();
        }
    }

    /// <summary>
    /// Opens the door and triggers associated events
    /// </summary>
    private void OpenDoor()
    {
        if (!isDoorOpend)
        {
            // Mark the door as opened to prevent re-opening
            isDoorOpend = true;

            // Set the "IsTheDoorOpen" parameter in the Animator to true
            animator.SetBool("IsTheDoorOpen", true);

           

            // Invoke the onDoorOpened event to trigger any additional actions
            onDoorOpened.Invoke();
        }
    }

    /// <summary>
    /// Called when another collider enters the trigger collider attached to this GameObject
    /// </summary>
    /// <param name="other">The other collider that has entered the trigger</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered is the player (assuming the player's GameObject is named "XR Origin (XR Rig)")
        if (other.gameObject.name == "XR Origin (XR Rig)")
        {
            // Trigger the _onZoneEntered event
            _onZoneEntered.Invoke();
        }
    }

    /// <summary>
    /// Sets the gotKey variable to true, indicating the player has acquired the key
    /// </summary>
    public void SetGotKey()
    {
        gotKey = true;
    }

    // Method to play a sound when the door is opened
    private void PlaySound()
    {
        // Get the AudioSource component attached to this GameObject and play the associated audio clip
        var snd = GetComponent<AudioSource>();
        snd.Play();
    }
}
