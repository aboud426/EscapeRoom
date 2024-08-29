using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.State;

public class AudioFindInteractableAffordance : MonoBehaviour
{
    /// <summary>
    /// Initializes the component by setting up the interactable source.
    /// </summary>
    public void Awake()
    {
        // Get the XRInteractableAffordanceStateProvider component attached to this GameObject
        // and set its interactableSource property to the XRBaseInteractable component
        // found in the parent GameObject.
        GetComponent<XRInteractableAffordanceStateProvider>().interactableSource =
            GetComponentInParent<XRBaseInteractable>();
    }
}
