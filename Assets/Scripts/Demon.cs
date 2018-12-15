using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Monster {

    [SerializeField]
    private int lives = 150;

    [SerializeField]
    private float acceleration = 0.1f;

    [SerializeField]
    private float rate = 2.0F;
    public float speed = 7.0F;
    private bool tired = false;
    public static bool oneThread = false;

    private Vector3 direction;
    private Vector3 firstPos;

    [SerializeField]
    private Transform target;

    private Bullet bullet;
    [SerializeField]
    private Color bulletColor = Color.red;

    private float time = 0;

    protected override void Awake()
    {
        if (!target) target = FindObjectOfType<Character>().transform;
        bullet = Resources.Load<Bullet>("Bullet");

        direction = transform.right;
    }

    protected override void Start()
    {
        InvokeRepeating("Shoot", rate, rate);
    }

    void Update()
    {
        GoToPlayer();

        if (!tired)
            Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, 
            speed * Time.deltaTime + acceleration * Time.deltaTime * Time.deltaTime / 2);
    }

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

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
            direction *= -1f;
    }

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
