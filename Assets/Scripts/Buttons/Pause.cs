using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \brief Вызов панели паузы
/// По нажатию кнопки, передающейся как сериализуемое поле, игра ставится на паузу,
/// а панель-паузы становится активной
public class Pause : MonoBehaviour {

    /// Булева переменная проверки паузы
    [HideInInspector]
    public bool isPaused = false;

    /// Кнопка паузы
    [SerializeField]
    private KeyCode pauseButton;
    /// Игровой объект - панель паузы
    [SerializeField]
    private GameObject panelPause;

    /// Called-every-frame функция, вызывающая панель паузы
    void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            isPaused = !isPaused;
        }

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
