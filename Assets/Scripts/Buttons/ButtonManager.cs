using System.Collections;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    public void PlayGame (GameObject obj)
    {
        obj.GetComponent<Pause>().isPaused = false;
    }

	public void ExitGame ()
    {
        Application.LoadLevel("main");
    }
}
