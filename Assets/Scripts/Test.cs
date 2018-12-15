using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        var scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * 2, scale.y * 2, scale.z);
    }

    void OnMouseDrag()
    {
        Vector2 p = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        transform.position = p;
    }

    void OnMouseUp()
    {
        var scale = transform.localScale;
        transform.localScale = new Vector3(scale.x / 2, scale.y / 2, scale.z);
    }
}
