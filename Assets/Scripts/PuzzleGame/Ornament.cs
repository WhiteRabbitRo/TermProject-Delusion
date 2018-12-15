using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ornament : MonoBehaviour {

    [SerializeField]
    private Transform puzzlePlace;

    private Vector2 initialPosition;

    private float deltaX, deltaY;

    [HideInInspector]
    public bool locked;

    private Ray ray;
    private RaycastHit hit;
    private Vector2 rot = new Vector2(0, 0);

	void Start ()
    {
        initialPosition = transform.position;
	}
	
	void Update ()
    {

	}

    void OnMouseDown()
    {
        if (!locked)
        {
            var scale = transform.localScale;
            transform.localScale = new Vector3(scale.x * 4, scale.y * 4, scale.z);
        }
    }

    void OnMouseDrag()
    {
        if (!locked)
        {
            Vector2 p = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = p;
        }
    }

    void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - puzzlePlace.position.x) <= 0.5f &&
                    Mathf.Abs(transform.position.y - puzzlePlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(puzzlePlace.position.x, puzzlePlace.position.y);
            locked = true;
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }

        if (!locked)
        {
            var scale = transform.localScale;
            transform.localScale = new Vector3(scale.x / 4, scale.y / 4, scale.z);
        }
    }
}
