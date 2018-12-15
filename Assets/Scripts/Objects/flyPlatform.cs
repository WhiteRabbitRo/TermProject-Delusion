using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// \brief Скрипт летающей платформы
public class flyPlatform : MonoBehaviour {

    [SerializeField]
    /// Связанный с платформой рычаг
    private Lever1 lever;

    [HideInInspector]
    /// Переменная для направления движения
    public bool i;

    /// Первый целевой объект
    public Transform target1;
    /// Второй целевой объект
    public Transform target2;

    /// Скорость полета платформы
    public float speed = 4.0F;

    /// Направление вправо
    void Start () {
        i = true;
	}
	
	/// Летим, если рычаг активирован
	void Update () {
        if (lever.flyPlatform)
            Fly();
	}

    /// Функция перемещения платформы
    void Fly()
    {
        if (i == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.position, speed * Time.deltaTime);
            
            if (transform.position == target1.position)
            {
                i = false;
            }
        }

        if (i == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);
            if (transform.position == target2.position)
            {
                i = true;
            }
        }
    }
}
