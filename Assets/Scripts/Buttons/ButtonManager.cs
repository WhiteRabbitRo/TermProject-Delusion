using System.Collections;
using UnityEngine;

/// \brief Мэнэджер для панели паузы
public class ButtonManager : MonoBehaviour {

/// Функция выводит объект из состояния паузы
    public void PlayGame (GameObject obj)
    {
        obj.GetComponent<Pause>().isPaused = false;
    }

/// Функция совершает переход на сцену main(UI)
	public void ExitGame ()
    {
        Application.LoadLevel("main");
    }
}
