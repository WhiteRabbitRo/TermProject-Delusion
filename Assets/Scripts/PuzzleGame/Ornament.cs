using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \brief Игра "Пазл" (скрипт кусочка пазла)
public class Ornament : MonoBehaviour {

    [SerializeField]
    /// Положение пазла
    private Transform puzzlePlace;

    /// Инициализируемое положение фигуры
    private Vector2 initialPosition;

    /// Допустимое смещение кусочка пазла
    private float deltaX, deltaY;

    [HideInInspector]
    /// Фиксация положения кусочка пазла
    public bool locked;

    /// Луч (для определения положения фиксации пазла)
    private Ray ray;
    /// Обнаружение луча
    private RaycastHit hit;
    private Vector2 rot = new Vector2(0, 0);

    /// Запоминаем положение кусочка пазла
	void Start ()
    {
        initialPosition = transform.position;
	}
	
	void Update ()
    {

	}

    /// При нажатии на кусочек - увеличиваем размер
    void OnMouseDown()
    {
        if (!locked)
        {
            var scale = transform.localScale;
            transform.localScale = new Vector3(scale.x * 4, scale.y * 4, scale.z);
        }
    }

    /// При перемещении мыши - перемещаем кусочек пазла
    void OnMouseDrag()
    {
        if (!locked)
        {
            Vector2 p = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = p;
        }
    }

    /// При отпускании мыши - проверка на фиксацию с правильным положением кусочка пазла
    void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - puzzlePlace.position.x) <= 0.5f &&
                    Mathf.Abs(transform.position.y - puzzlePlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(puzzlePlace.position.x, puzzlePlace.position.y);
            locked = true;
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }

        if (!locked)
        {
            var scale = transform.localScale;
            transform.localScale = new Vector3(scale.x / 4, scale.y / 4, scale.z);
        }
    }
}
