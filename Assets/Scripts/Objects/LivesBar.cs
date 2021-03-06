﻿using UnityEngine;
using System.Collections;

/// \brief Панель здоровья
public class LivesBar : MonoBehaviour
{
    /// Массив очков здоровья
    private Transform[] hearts = new Transform[5];

    /// Игрок
    private Character character;

    /// Заполняем массив количеством очков здоровья у игрока
    private void Awake()
    {
        character = FindObjectOfType<Character>();

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
            Debug.Log(hearts[i]);
        }
    }

    /// Обновлене панели
    public void Refresh()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < character.Lives) hearts[i].gameObject.SetActive(true);
            else hearts[i].gameObject.SetActive(false);
        }
    }
}
