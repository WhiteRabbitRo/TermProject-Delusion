using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theEndController : MonoBehaviour {

    [SerializeField]
    private GameObject theEnd;

    void Update()
    {
        if (Demon.oneThread)
        {
            theEnd.SetActive(true);
        }
    }
}
