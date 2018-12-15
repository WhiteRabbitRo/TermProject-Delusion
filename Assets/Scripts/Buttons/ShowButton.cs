using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \brief Кнопка панели паузы
public class ShowButton : MonoBehaviour {

    /// Hide-переменная проверки паузы
    [HideInInspector]
    public bool isPaused = false;

    /// Сериализуемая переменная игрового объекта - панель паузы
    [SerializeField]
    private GameObject panelPause;

    /// Функция появления панели
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
