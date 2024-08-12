using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    [SerializeField] private bool keyNeeded = false;              //Is key needed for the door
    public bool gotKey;                  //Has the player acquired key
    public GameObject keyGameObject;            //If player has Key,  assign it here
    private UnityEvent _onZoneEntered = new();
    [SerializeField] private GameObject _departmentDoor;

    //private bool playerInZone;                  //Check if the player is in the zone
   // private bool doorOpened;                    //Check if door is currently opened or not

    //private BoxCollider doorCollider;           //To enable the player to go through the door if door is opened else block him

    private Animator animator;
    enum DoorState
    {
        Closed,
        Opened
    }

    //DoorState doorState ;      //To check the current state of the door

    private void OnEnable()
    {
        _onZoneEntered.AddListener(CheckDoorOpenConditions);
    }

    private void OnDisable()
    {
        _onZoneEntered.RemoveListener(CheckDoorOpenConditions);
    }

    /// <summary>
    /// Initial State of every variables
    /// </summary>
    private void Start()
    {
        gotKey = false;
        //doorOpened = false;                     //Is the door currently opened
        //playerInZone = false;                   //Player not in zone
        //doorState = DoorState.Closed;           //Starting state is door closed

        animator = _departmentDoor.GetComponent<Animator>();
        
        //doorCollider = _departmentDoor.GetComponent<BoxCollider>();
    }

    private void CheckDoorOpenConditions()
    {
        if (keyNeeded)
        {
            // check conditions then open door
            if (gotKey)
            {
                _departmentDoor.GetComponent<Collider>().enabled = false;
                OpenDoor();
            }
        }
        else
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        animator.SetBool("IsTheDoorOpen", true);
        //doorState = DoorState.Opened;
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.name == "XR Origin (XR Rig)")
        {
            _onZoneEntered.Invoke();    
        }
    }
    public void SetGotKey()
    {
        gotKey = true;
    }

    
}
