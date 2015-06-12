using UnityEngine;
using System.Collections;

public class flameScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.UpArrow)) {
			Debug.Log ("Arriba");
		} 
		else if (Input.GetKey (KeyCode.DownArrow)) {
			Debug.Log ("Abajo");
		}
	}
}
