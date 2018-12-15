using UnityEngine;
using System.Collections;

/// \brief Очко здоровья
public class Heart : MonoBehaviour
{
    /// При встрече с игроком прибавляет +1 жизнь
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();
        
        if (character)
        {
            character.Lives++;
            Destroy(gameObject);
        }
    }
}
