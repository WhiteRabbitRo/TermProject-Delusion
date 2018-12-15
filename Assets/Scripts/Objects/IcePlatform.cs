using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \warning Не используется
public class IcePlatform : MonoBehaviour {

    public float acceleration = 1.0F;

    private void OnTriggerEnter2D (Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if (character)
        {
            Rigidbody2D body = character.GetComponent<Rigidbody2D>();
            body.AddForce(transform.up * acceleration);
        }
    }
}
