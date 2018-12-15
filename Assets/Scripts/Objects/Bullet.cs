using UnityEngine;
using System.Collections;

/// \brief Скрипт магического снаряда (пули)
public class Bullet : MonoBehaviour
{
    private GameObject parent; /// Объект, выпустивший снаряд
    public GameObject Parent { set { parent = value; }  get { return parent; } }

    private float speed = 10.0F; /// Скорость полета пули
    [HideInInspector]
    public Vector3 direction; /// Направление движения пули
    public Vector3 Direction { set { direction = value; } }

    /// Цвет пули
    public Color Color
    {
        set { sprite.color = value; }
    }

    private SpriteRenderer sprite; /// Компонент игрового объекта - спрайт

    /// Получаем компонент - спрайт
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    /// Уничтожаем объект через определенное время
    private void Start()
    {
        Destroy(gameObject, 1.4F);
    }
	
    /// Движемся согласно направлению
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }

    /// При встрече с Unit-объектом - уничтожаем пулю
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit.gameObject != parent)
        {
            Destroy(gameObject);
        }
    }
}
