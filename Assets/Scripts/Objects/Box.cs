using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    [SerializeField]
    private CameraController camera;

    [SerializeField]
    private GameObject mainGame;

    [SerializeField]
    private GameObject canvasGame;

    [SerializeField]
    private OrnamentManager ornament;

    public GameObject newInstrument;

    private void OnTriggerEnter2D (Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();

        if (character)
        {
            camera.findPlayer = false;
            mainGame.SetActive(false);
            canvasGame.SetActive(true);
        }

        if (ornament.wellDone)
        {
            camera.findPlayer = true;
            Debug.Log("Игра пройдена");
            character.canMakeMagic = true;

            newInstrument.SetActive(true);
            if (Input.GetButton("Fire1"))
            {
                newInstrument.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
