using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterOpenDoorKeyController : MonoBehaviour
{
    // Reference to the key GameObject that will be managed by this script
    [SerializeField] private GameObject key;

    // Method to make the key disappear when the player wins
    public void DisappeareWhenWin()
    {
        // Deactivate the key GameObject, making it invisible and inactive
        key.gameObject.SetActive(false);
    }
}
