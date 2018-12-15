using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour {

    [SerializeField]
    private GameObject platform;

    public bool flyPlatform = false;

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
	
	// Update is called once per frame
	void Update () {
		
	}
}
