using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseTheGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool IsActive=true;
    // Start is called before the first frame update
    void Start()
    {
        ToggleMenu();
    }

    public void ToggleMenu()
    {
        if (IsActive) 
        {
            pauseMenu.SetActive(false);
            IsActive = false;
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.SetActive(true);
            IsActive = true;
            Time.timeScale = 0;
        }
    }
    public void PauseButtonPressed(InputAction.CallbackContext context) 
    {
        if (context.performed)
        {
            ToggleMenu();
        }
    }
    public void Resume()
    {
        ToggleMenu();
    }
   

}
