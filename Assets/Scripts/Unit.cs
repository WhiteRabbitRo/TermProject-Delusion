using UnityEngine;
using System.Collections;

/// \brief Скрипт "живых" объектов
public class Unit : MonoBehaviour
{
    /// При получении урона - функция смерти
    public virtual void ReceiveDamage()
    {
        Die();
    }

    /// Разрушение объекта
    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
