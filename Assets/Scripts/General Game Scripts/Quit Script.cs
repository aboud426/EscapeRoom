using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour
{
    [SerializeField] private GameObject _quitPanel;

    public void Start()
    {
        _quitPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ActivateQuitPanel()
    {
        _quitPanel.SetActive(true);
    }
    public void DisableQuitPanel()
    {
        _quitPanel.SetActive(false);
    }
}
