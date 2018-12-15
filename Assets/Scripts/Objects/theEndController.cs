using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \brief Контроллера конца игры
public class theEndController : MonoBehaviour {

    [SerializeField]
    /// Панель с порталом
    private GameObject theEnd;

    /// Если демон побежден - открыть портал
    void Update()
    {
        if (Demon.oneThread)
        {
            theEnd.SetActive(true);
        }
    }
}
