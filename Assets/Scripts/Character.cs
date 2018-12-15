using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Linq;

/// \brief Скрипт игрока
[System.Serializable]
public class Character : Unit
{
    [SerializeField]
    private int lives = 5; /// Количество жизней

    [SerializeField]
    private string nameOfLevel = "Level"; /// Название текущего уровня (для респавна)

    public bool canMakeMagic = false; /// Проверка на возможность создания магического снаряда
    public bool canBeProtected = false; /// Проверка на возможность создания магического щита

    public int Lives
    {
        get { return lives; }
        set
        {
           if (value <= 5) lives = value;
            livesBar.Refresh();
        }
    }
    private LivesBar livesBar; /// Панель очков здоровья

    public float speed = 3.0F; /// Скорость персонажа
    [SerializeField]
    private float jumpForce = 15.0F; /// Сила прыжка

    private bool isGrounded = false; /// Проверка на нахождение на земле

    private Bullet bullet; /// Компонент "Пуля"

    private CharState State /// Анимация персонажа
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody; /// Компонент "Физическое тело"
    private Animator animator; /// Компонент "Аниматор"
    private SpriteRenderer sprite; /// Компонент "Спрайт"
    private Shield shield; /// Компонент "Щит"
    private AudioSource[] audio;

    /// Получаем компоненты из игрового объекта
    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        audio = GetComponents<AudioSource>();

        bullet = Resources.Load<Bullet>("Bullet");
        shield = Resources.Load<Shield>("Shield");
    }

    /// Проверяем нахождение игрока на земле (для прыжка) и падение за пределы карты
    private void FixedUpdate()
    {
        CheckGround();

        if (transform.position.y < -10)
            SceneManager.LoadScene(nameOfLevel);
    }

    /// Активация действий и соответствующих анимаций
    private void Update()
    {
        if (isGrounded) State = CharState.Idle;

        if (Input.GetButtonDown("Fire1"))
            if (canMakeMagic)
                Shoot();
        if (Input.GetButtonDown("Fire2"))
            if (canBeProtected)
                Protect();

        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump();

        if (!Input.GetButton("Horizontal")) isFlyPlatform();
    }

    /// Функция бега
    private void Run()
    {

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;

        if (isGrounded)
        {
            State = CharState.Run;
        }
    }

    /// Функция прыжка
    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    /// Функция стрельбы
    private void Shoot()
    {
        Vector3 position = transform.position; position.y += 0.8F;
        Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
    }

    /// Функция щита
    private void Protect()
    {
        Vector3 position = transform.position;
        position.y += gameObject.GetComponent<BoxCollider2D>().size.y / 2;
        Shield newShield = Instantiate(shield, position, shield.transform.rotation) as Shield;
    }

    /// Получение урона (уменьшение очков здоровья на -1, при нуле - респавн)
    public override void ReceiveDamage()
    {
        Lives--;

        if (Lives == 0)
            SceneManager.LoadScene(nameOfLevel);

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);

        Debug.Log(lives);
    }

    /// Функция проверка нахождения игрока на земле
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);

        if (colliders.All(x => !x.GetComponent<Shield>()))
            isGrounded = colliders.Length > 1;

        if (!isGrounded) State = CharState.Jump;
    }

    /// Функция параллельного перемещения игрока на летящей платформе
    private void isFlyPlatform()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1F);

        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; ++i)
            {
                flyPlatform platform = colliders[i].GetComponent<flyPlatform>();
                if (platform)
                {
                    Vector3 characterMove = transform.position;
                    if (platform.i) characterMove.x += platform.speed / 2 * Time.deltaTime;
                    else characterMove.x -= platform.speed / 2 * Time.deltaTime;

                    transform.position = characterMove;
                }
            }
        }
    }

    /// При встрече с пулей (не от игрока) - получение урона
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Bullet bullet = collider.gameObject.GetComponent<Bullet>();
        if (bullet && bullet.Parent != gameObject)
        {
            ReceiveDamage();
        }
    }
}

/// Анимация
public enum CharState
{
    Idle, /// < Бездействие
    Run, /// < Бег
    Jump /// < Прыжок
}