using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0F;

    public bool findPlayer = true;

    [SerializeField]
    private Transform target;

    private void Awake()
    {
        if (findPlayer)
            if (!target) target = FindObjectOfType<Character>().transform;
    }

    private void Update()
    {
        if (findPlayer)
        {
            Vector3 position = target.position; position.z = -10.0F;
            transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
        }
    }
}
