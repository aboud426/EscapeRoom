using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class AnimateHandController : MonoBehaviour
{
    // Reference to the InputAction for grip input
    public InputActionReference gripInputActionReference;

    // Reference to the InputAction for trigger input
    public InputActionReference triggerInputActionReference;

    // Reference to the Animator component on this GameObject
    private Animator _handAnimator;

    // Variables to store the current values of grip and trigger inputs
    private float _gripValue;
    private float _triggerValue;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Animator component
        _handAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the hand animation based on the grip and trigger input values
        AnimateGrip();
        AnimateTrigger();
    }

    // Method to update the animation based on the trigger input
    private void AnimateTrigger()
    {
        // Read the current value of the trigger input action
        _triggerValue = triggerInputActionReference.action.ReadValue<float>();

        // Set the "Trigger" parameter in the Animator to the trigger input value
        _handAnimator.SetFloat("Trigger", _triggerValue);
    }

    // Method to update the animation based on the grip input
    private void AnimateGrip()
    {
        // Read the current value of the grip input action
        _gripValue = gripInputActionReference.action.ReadValue<float>();

        // Set the "Grip" parameter in the Animator to the grip input value
        _handAnimator.SetFloat("Grip", _gripValue);
    }
}
