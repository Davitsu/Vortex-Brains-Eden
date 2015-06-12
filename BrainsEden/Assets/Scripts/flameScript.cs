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
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			Debug.Log ("Arriba");
			this.GetComponent<ParticleSystem>().enableEmission= true;
		} 
		else if (Input.GetKeyUp (KeyCode.DownArrow)) {
			Debug.Log ("Abajo");
			this.GetComponent<ParticleSystem>().enableEmission= false;
		}
	}
}
