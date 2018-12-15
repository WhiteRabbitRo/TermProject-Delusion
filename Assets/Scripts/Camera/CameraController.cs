using UnityEngine;
using System.Collections;

/// \brief Контроллер камеры
public class CameraController : MonoBehaviour
{
    /// Скорость движения камеры
    [SerializeField]
    private float speed = 2.0F;

    /// Булева переменная разрешения на поиск персонажа
    public bool findPlayer = true;

    /// Положение игрока
    [SerializeField]
    private Transform target;

    /// Если поиск разрешен - находим позицию игрока и запоминаем
    private void Awake()
    {
        if (findPlayer)
            if (!target) target = FindObjectOfType<Character>().transform;
    }

    /// Если поиск разрешен - меняем положение камеры относительно позиции игрока
    private void Update()
    {
        if (findPlayer)
        {
            Vector3 position = target.position; position.z = -10.0F;
            transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
        }
    }
}
