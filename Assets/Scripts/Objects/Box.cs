using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \brief Скрипт сундука с магическим снарядом
public class Box : MonoBehaviour {

    [SerializeField]
    /// Скрипт главной камеры
    private CameraController camera;

    [SerializeField]
    /// Объект с главной игрой
    private GameObject mainGame;

    [SerializeField]
    /// Объект с панелью игры "Пазл"
    private GameObject canvasGame;

    [SerializeField]
    /// Мэнэджер игры "Пазл"
    private OrnamentManager ornament;

    /// Объект с панелью магического снаряда
    public GameObject newInstrument;

    /// При встрече с персонажем выводим панель с игрой "Пазл", убираем главную игру
    /// После прохождения - возвращаем исходную позицию, выводим панель магического снаряда
    private void OnTriggerEnter2D (Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if (character)
        {
            camera.findPlayer = false;
            mainGame.SetActive(false);
            canvasGame.SetActive(true);
        }

        if (ornament.wellDone)
        {
            camera.findPlayer = true;
            Debug.Log("Игра пройдена");
            character.canMakeMagic = true;

            newInstrument.SetActive(true);
            if (Input.GetButton("Fire1"))
            {
                newInstrument.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
