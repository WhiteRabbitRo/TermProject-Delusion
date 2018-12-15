using UnityEngine;
using System.Collections;
using System.Linq;


/// \brief Скрипт двигающегося врага
public class MoveableMonster : Monster
{
    [SerializeField]
    private float speed = 2.0F; /// Скорость

    private Vector3 direction; /// Направление
    private SpriteRenderer sprite; /// Компонент игрового объекта: спрайт

    /// Получаем компонент "спрайт"
    protected override void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    /// Первоначальное направление движения - вправо
    protected override void Start()
    {
        direction = transform.right;
    }

    /// Двигаемся по-кадрово
    protected override void Update()
    {
        Move();
    }

    /// При прыжке игрока сверху - получаем урон, при встрече с пулей - получаем урон
    /// при встрече с "пустым объектом" - разворачиваемся
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) ReceiveDamage();
            else unit.ReceiveDamage();
        }

        Bullet bullet = collider.GetComponent<Bullet>();

        if (bullet)
        {
            ReceiveDamage();
        }

        empty empty = collider.GetComponent<empty>();
        if(empty)
        {
            direction *= -1.0F;
            sprite.flipX = !sprite.flipX;
        }
    }

    /// Движение объекта
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
}
