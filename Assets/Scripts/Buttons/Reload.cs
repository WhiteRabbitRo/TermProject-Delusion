using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \brief Перезагрузки уровня
public class Reload : MonoBehaviour {

    /// Переменная с названием уровня
    public string name = "ChessGame";

    /// Функция перезагрузки уровня
	public void Re()
    {
        Application.LoadLevel(name);
    }
}
