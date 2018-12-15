using UnityEngine;
using System.Collections;

/// \brief Скрипт препятствий
public class Obstacle : MonoBehaviour
{
    /// При встрече с игроком - игрок получает урон
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.GetComponent<Unit>();

        if (unit && unit is Character)
        {
            unit.ReceiveDamage();
        }
    }
}
