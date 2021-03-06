﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \brief Скрипт босса "Демона"
public class Demon : Monster {

    [SerializeField]
    /// Количество очков здоровья
    private int lives = 150;

    [SerializeField]
    /// Ускорение
    private float acceleration = 0.1f;

    [SerializeField]
    /// Время повторения стрельбы магическими снарядами
    private float rate = 2.0F;
    /// Скорость
    public float speed = 7.0F;
    /// Проверка на бездействие
    private bool tired = false;
    /// Проверка на смерть
    public static bool oneThread = false;

    /// Направление движения
    private Vector3 direction;
    /// Начальная позиция
    private Vector3 firstPos;

    [SerializeField]
    /// Позиция игрока
    private Transform target;

    /// Компонент "Пуля"
    private Bullet bullet;

    [SerializeField]
    private Color bulletColor = Color.red;

    /// Время для проверки на бездействие
    private float time = 0;

    /// Находим положение игрока, загружаем объект "Пуля", направление - вправо
    protected override void Awake()
    {
        if (!target) target = FindObjectOfType<Character>().transform;
        bullet = Resources.Load<Bullet>("Bullet");

        direction = transform.right;
    }

    /// Запускаем повторение функции стрельбы
    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

    /// Проверяем на бездействие (каждые 20 секунд стремится за игроком) и функция движения
    void Update()
    {
        GoToPlayer();

        if (!tired)
            Move();
    }

    /// Движение объекта
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, 
            speed * Time.deltaTime + acceleration * Time.deltaTime * Time.deltaTime / 2);
    }

    /// Функция стрельбы (если не в бездействии)
    void Shoot()
    {
        if (!tired)
        {
            Vector3 position = transform.position; position.y += 0.8F;
            Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

            newBullet.Parent = gameObject;
            newBullet.Direction = target.transform.position - position;
        }
    }

    /// Функция преследования персонажа (бездействия)
    void GoToPlayer()
    {
        time += Time.deltaTime;

        if (time > 10)
        {
            Debug.Log("Demon is tired");

            if (time < 11)
            {
                firstPos = transform.position;
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime +
                    acceleration * Time.deltaTime * Time.deltaTime / 2);
            }

            tired = true;

            if (time > 20)
            {
                transform.position = Vector3.MoveTowards(transform.position, firstPos, speed * Time.deltaTime +
                    acceleration * Time.deltaTime * Time.deltaTime / 2);
                time = 0;
                tired = false;
            }
        }
    }

    /// При столкновении со стеной - поменять направление
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
            direction *= -1f;
    }

    /// При столкновении с игроком - игрок получает урон, при столкновении с пулей - объект получает урон
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) ReceiveDamage();
            else unit.ReceiveDamage();
        }

        Bullet bullet = collider.GetComponent<Bullet>();

        if (bullet && bullet.Parent != gameObject)
        {
            ReceiveDamage();
        }
    }

    /// Функция получения урона (если очков здоровья ноль - упасть на землю, умереть, открыть портал)
    public override void ReceiveDamage()
    {
        --lives;
        Debug.Log(lives);

        if (lives == 0)
        {
            tired = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
            oneThread = true;
            Die();
        }
    }
}
