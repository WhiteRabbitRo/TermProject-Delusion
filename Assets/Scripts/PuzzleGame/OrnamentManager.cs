using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \brief Игра "Пазл" (мэнэджер игры)
public class OrnamentManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainGame; /// Объект с главной игрой

    [SerializeField]
    private GameObject canvasGame; /// Объект с игрой "Пазл"

    public GameObject panel; /// Панель с пазлом
    public Ornament[] _puzzle; /// Массив кусочков пазла

    public bool wellDone = false; /// Переменная выигрыша

    private int num; /// Переменная проверки сборки пазла

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
