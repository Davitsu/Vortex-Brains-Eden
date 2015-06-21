using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ScaleBox(float scaleX, float scaleY) {
		this.transform.localScale = new Vector3 (scaleX, scaleY, 1);
	}
}
