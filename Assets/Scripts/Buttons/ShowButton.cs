using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButton : MonoBehaviour {

    [HideInInspector]
    public bool isPaused = false;

    [SerializeField]
    private GameObject panelPause;

    public void Show ()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            panelPause.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else
        {
            panelPause.SetActive(false);
            Time.timeScale = 1;
        }

    }
}
