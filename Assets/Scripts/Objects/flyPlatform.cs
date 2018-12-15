using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class flyPlatform : MonoBehaviour {
    [SerializeField]
    private Lever1 lever;

    [HideInInspector]
    public bool i;

    public Transform target1;
    public Transform target2;

    public float speed = 4.0F;

    // Use this for initialization
    void Start () {
        i = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (lever.flyPlatform)
            Fly();
	}

    void Fly()
    {
        if (i == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.position, speed * Time.deltaTime);
            
            if (transform.position == target1.position)
            {
                i = false;
            }
        }

        if (i == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);
            if (transform.position == target2.position)
            {
                i = true;
            }
        }
    }
}
