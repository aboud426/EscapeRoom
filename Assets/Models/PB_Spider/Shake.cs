using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour

{
    public float shakeAmount = 0.1f;  // How much it shakes
    public float shakeSpeed = 20f;    // How fast it shakes
    public float shakeDuration = 0.5f; // Duration of each shake
    public float intervalBetweenShakes = 0.5f; // Time between shakes

    private Vector3 originalPosition;
    private bool isShaking = true;

    void Start()
    {
        originalPosition = transform.localPosition; // Store the original position of the object
    }

    void Update()
    {
        // If shaking is active, continue to shake the object
        if (isShaking)
        {
            StartCoroutine(ShakeWithInterval());
        }
    }

    private IEnumerator ShakeWithInterval()
    {
        isShaking = false; // Prevent multiple coroutines from starting at the same time

        // Shake the object
        Vector3 offset = Random.insideUnitSphere * shakeAmount;
       transform.localPosition = originalPosition + new Vector3(Mathf.Sin(Time.time * shakeSpeed) * shakeAmount, 0, 0);

        // Wait for the duration of the shake
        yield return new WaitForSeconds(shakeDuration);

        // Reset to the original position after shaking
        transform.localPosition = originalPosition;

        // Wait for the interval between shakes
        yield return new WaitForSeconds(intervalBetweenShakes);

        isShaking = true; // Start the next shake cycle
    }

    public void StartShaking()
    {
        isShaking = true;
        StartCoroutine(ShakeWithInterval());
    }

    public void StopShaking()
    {
        isShaking = false;
        StopAllCoroutines();
        transform.localPosition = originalPosition; // Ensure the position is reset
    }
}











/*
 
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] private bool start = false;
    [SerializeField] private float duration = 1.0f;
    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    private IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }
        transform.position = startPosition;
    }
}

 */