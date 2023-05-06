using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FailSC : MonoBehaviour
{
    public GameObject failPanel;

    void Start()
    {
        failPanel.SetActive(false);

    }
    public void ShowFailPanel()
    {
        // Stop the time scale
        Time.timeScale = 0.0f;
        Debug.Log("fail");
        // Enable the failPanel
        failPanel.SetActive(true);
    }
}


