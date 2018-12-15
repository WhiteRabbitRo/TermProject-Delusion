using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// \brief Триггер двери
/// \warning Не используется
public class DoorTrigger : MonoBehaviour {
    [SerializeField]
    private string name = "ChessGame";
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character unit = collider.gameObject.GetComponent<Character>();
        if (unit)
        {
            Debug.Log("New level");
            Application.LoadLevel(name);
        }
    }
}
