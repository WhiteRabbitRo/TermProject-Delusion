using UnityEngine;
using System.Collections;

/// \brief Стреляющий враг
public class ShootableMonster : Monster
{
    [SerializeField]
    private float rate = 2.0F; /// время повторения стрельбы

    [SerializeField]
    private Color bulletColor = Color.white; /// цвет снаряда

    [SerializeField]
    private bool direction = true; /// направление снаряда

    private Bullet bullet; /// объект - пуля (снаряд)
    public float positionY = 0.5F; /// смещение по Y положения появления пули

    /// Загружаем сохраненный объект "Пуля"
    protected override void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet");
    }

    /// Повторяем функцию стрельбы в соответствии с временем повторения
    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

    /// Функция стрельбы пулями
    private void Shoot()
    {
        Vector3 position = transform.position;
        position.y += positionY;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;

        if (direction) newBullet.Direction = -newBullet.transform.right;
        else newBullet.Direction = newBullet.transform.right;

        newBullet.Color = bulletColor;
    }

    /// При встрече с игроком - игрок получаем урон
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.3F) ReceiveDamage();
            else unit.ReceiveDamage();
        }
    }
}
