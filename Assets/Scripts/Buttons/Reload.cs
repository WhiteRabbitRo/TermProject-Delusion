using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour {
    public string name = "ChessGame";
	public void Re()
    {
        Application.LoadLevel(name);
    }
}
