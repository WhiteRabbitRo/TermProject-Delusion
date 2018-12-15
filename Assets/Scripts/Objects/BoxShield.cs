using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// \brief Скрипт сундука для "Пятнашек"
public class BoxShield : MonoBehaviour {

    /// При встрече с игроком - загружаем уровень "Пятнашки"
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if (character)
        {
            SceneManager.LoadScene("ChessGame");
        }
    }
}
