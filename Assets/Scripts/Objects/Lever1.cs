using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \brief Рычаг
public class Lever1 : MonoBehaviour {

    [SerializeField]
    /// Связанная с рычагом платформа
    private GameObject platform;

    /// Переменная активации рычага
    public bool flyPlatform = false;

    /// При встрече с игроком активируется рычаг
	private void OnTriggerEnter2D (Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if (character && !flyPlatform)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            flyPlatform = !flyPlatform;
        }
    }
}
