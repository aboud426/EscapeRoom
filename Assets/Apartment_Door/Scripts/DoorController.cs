using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    [SerializeField] private bool keyNeeded = false;              //Is key needed for the door
    public bool gotKey;                  //Has the player acquired key
    public GameObject keyGameObject;            //If player has Key,  assign it here

    private bool playerInZone;                  //Check if the player is in the zone
   // private bool doorOpened;                    //Check if door is currently opened or not

    private BoxCollider doorCollider;           //To enable the player to go through the door if door is opened else block him

    private Animator animator;
    enum DoorState
    {
        Closed,
        Opened
    }

    DoorState doorState ;      //To check the current state of the door

    /// <summary>
    /// Initial State of every variables
    /// </summary>
    private void Start()
    {
        gotKey = false;
        //doorOpened = false;                     //Is the door currently opened
        playerInZone = false;                   //Player not in zone
        doorState = DoorState.Closed;           //Starting state is door closed

        animator = transform.parent.gameObject.GetComponent<Animator>();
        
        doorCollider = transform.parent.gameObject.GetComponent<BoxCollider>();

        //If Key is needed and the KeyGameObject is not assigned, stop playing and throw error
        if (keyNeeded && keyGameObject == null)
        {
            //UnityEditor.EditorApplication.isPlaying = false;
            Debug.LogError("Assign Key GameObject");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.name == "XR Origin (XR Rig)")
        {
            playerInZone = true;
        }
    }
    public void SetGotKey()
    {
        gotKey = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "XR Origin (XR Rig)")
        {
            playerInZone = false;
        }
    }

    private void Update()
    {
        //To Check if the player is in the zone
        if (playerInZone)
        {
            

            if (doorState == DoorState.Opened)
            {
                
                doorCollider.enabled = false;
            }
            else 
            {
                
                doorCollider.enabled = true;
            }
             if (doorState == DoorState.Closed)
            {
                if (!keyNeeded)
                {
                animator.SetBool("IsTheDoorOpen", true);
                doorState = DoorState.Opened;
                }
            }

            if (doorState == DoorState.Closed && gotKey)
            {
                
                animator.SetBool("IsTheDoorOpen", true);
                doorState = DoorState.Opened;
            }
        }

        
    }
}
