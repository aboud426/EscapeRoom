using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOut : MonoBehaviour
{
    // Reference to the Animator component that controls the key's animations
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the animator by getting the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    // Method to trigger the key-out animation
    public void AnimateKey()
    {
        // Set the "IsOut" parameter in the Animator to true, triggering the key-out animation
        animator.SetBool("IsOut", true);
    }

    // Method to disable the key-out animation
    public void DisableAnimation()
    {
        // Set the "IsOut" parameter in the Animator to false, stopping the key-out animation
        animator.SetBool("IsOut", false);
    }
}
