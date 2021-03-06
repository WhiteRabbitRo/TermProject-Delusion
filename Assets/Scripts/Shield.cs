﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// \brief Магический щит
public class Shield : MonoBehaviour {

    /// Уничтожить объект спустя некоторое время
    private void Start()
    {
        Destroy(gameObject, 1.0F);
    }

    /// При попадании в зону защиты пули - уничтожить пулю
    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2.0F);

        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; ++i)
            {
                if (colliders[i].GetComponent<Bullet>())
                {
                    Destroy(colliders[i].gameObject);
                }
            }
        }
    }
}
