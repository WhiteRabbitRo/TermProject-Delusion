using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \brief Игра "Пазл" (мэнэджер игры)
public class OrnamentManager : MonoBehaviour
{
    [SerializeField]
    /// Объект с главной игрой
    private GameObject mainGame;

    [SerializeField]
    /// Объект с игрой "Пазл"
    private GameObject canvasGame;

    /// Панель с пазлом
    public GameObject panel;
    /// Массив кусочков пазла
    public Ornament[] _puzzle;

    /// Переменная выигрыша
    public bool wellDone = false;

    /// Переменная проверки сборки пазла
    private int num;

    void Start () {
		
	}

	/// Проверяем все ли кусочки на своих местах
	void Update () {
        for (int x = 0; x < _puzzle.Length; ++x)
        {
            if (_puzzle[x].locked)
            {
                ++num;
            }
        }

        if (num == _puzzle.Length)
        {
            Debug.Log("All puzzles are locked");
            wellDone = true;
            mainGame.SetActive(true);
            canvasGame.SetActive(false);
        }

        num = 0;
	}
}
