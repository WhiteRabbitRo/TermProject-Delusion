using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour {

    [SerializeField]
    private Vector3 place;

    [SerializeField]
    private GameObject newInstrument;

    public GameObject box;
    private bool end = false;

	void Start () {
		if (ChessGameControl.win)
        {
            transform.position = place;
            Destroy(box);
            gameObject.GetComponent<Character>().canBeProtected = true;
        }
	}

	void Update () {
        if (!end)
        {
            if (ChessGameControl.win)
            {
                newInstrument.SetActive(true);

                if (Input.GetButtonDown("Fire2"))
                {
                    newInstrument.SetActive(false);
                    end = true;
                }
            }
        }
	}
}
