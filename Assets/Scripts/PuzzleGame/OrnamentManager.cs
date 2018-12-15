using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnamentManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainGame;

    [SerializeField]
    private GameObject canvasGame;

    public GameObject panel;
    public Ornament[] _puzzle;

    public bool wellDone = false;

    private int num;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int x = 0; x < _puzzle.Length; ++x)
        {
            if (_puzzle[x].locked)
            {
                ++num;
            }
        }

        if (num == _puzzle.Length)
        {
            Debug.Log("All puzzles are locked");
            wellDone = true;
            mainGame.SetActive(true);
            canvasGame.SetActive(false);
        }

        num = 0;
	}
}
