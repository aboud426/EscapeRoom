using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IdiomChestScript : MonoBehaviour
{
    // Reference to the Animator component that controls the chest's animations
    private Animator animator;

    // UnityEvent that gets invoked when the chest is opened
    [HideInInspector] public UnityEvent onBoxOpened;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the animator by getting the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    // Called when the GameObject becomes enabled and active
    private void OnEnable()
    {
        // Subscribe the PlaySound method to the onBoxOpened event, so it gets called when the event is triggered
        onBoxOpened.AddListener(PlaySound);
    }

    // Called when the GameObject becomes disabled or inactive
    private void OnDisable()
    {
        // Unsubscribe the PlaySound method from the onBoxOpened event to prevent memory leaks or unexpected behavior
        onBoxOpened.RemoveListener(PlaySound);
    }

    // Method to open the chest and trigger the event
    public void GetPrize()
    {
        // Set the "IsOpen" parameter in the Animator to true, triggering the opening animation
        animator.SetBool("IsOpen", true);

        // Invoke the onBoxOpened event, which will call all subscribed methods (like PlaySound)
        onBoxOpened.Invoke();
    }

    // Method to play a sound when the chest is opened
    private void PlaySound()
    {
        // Get the AudioSource component attached to this GameObject and play the associated audio clip
        var snd = GetComponent<AudioSource>();
        snd.Play();
    }
}
