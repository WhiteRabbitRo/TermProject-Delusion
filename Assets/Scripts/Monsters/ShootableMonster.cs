using UnityEngine;
using System.Collections;

public class ShootableMonster : Monster
{
    [SerializeField]
    private float rate = 2.0F;

    [SerializeField]
    private Color bulletColor = Color.white;

    [SerializeField]
    private bool direction = true;

    private Bullet bullet;
    public float positionY = 0.5F;

    protected override void Awake()
    {
        bullet = Resources.Load<Bullet>("Bullet");
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

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
