using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireworkController : MonoBehaviour
{
    // Reference to the firework GameObject that will be activated
    [SerializeField] private GameObject Firework;

    // UnityEvent that gets invoked when the firework is activated
    [HideInInspector] public UnityEvent onFireworkActivated;

    // Start is called before the first frame update
    public void Start()
    {
        // Initially disable the firework GameObject so it is not visible or active
        Firework.SetActive(false);
    }

    // Called when the GameObject becomes enabled and active
    private void OnEnable()
    {
        // Subscribe the PlaySound method to the onFireworkActivated event
        onFireworkActivated.AddListener(PlaySound);
    }

    // Called when the GameObject becomes disabled or inactive
    private void OnDisable()
    {
        // Unsubscribe the PlaySound method from the onFireworkActivated event
        onFireworkActivated.RemoveListener(PlaySound);
    }

    // Method to activate the firework when the player wins
    public void PlayWhenWin()
    {
        // Enable the firework GameObject
        Firework.SetActive(true);

        // Invoke the onFireworkActivated event, which will trigger any subscribed methods like PlaySound
        onFireworkActivated.Invoke();
    }

    // Method to play a sound when the firework is activated
    private void PlaySound()
    {
        // Get the AudioSource component attached to this GameObject and play the associated audio clip
        var snd = GetComponent<AudioSource>();
        snd.Play();
    }
}
