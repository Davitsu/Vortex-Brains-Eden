using UnityEngine;
using System.Collections;
using UnityEngine.UI;				//clase Toggle
using UnityEngine.EventSystems;		//IsPointerOverGameObject-> comprueba si un input esta encima de otroGame object


public class pickDrop : MonoBehaviour {

	public Toggle botonCubo;
	public Toggle botonEsfera;
	
	private bool botonApretado;
	
	void Awake(){
		Input.multiTouchEnabled = false;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		if(Input.touchCount > 0)
		{
			if(Input.touches[0].phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
			{
				if(botonCubo.isOn)
				{
					crearObjecto(0, Vector3.zero);
				}
				else if(botonEsfera.isOn)
				{
					crearObjecto(1, Vector3.zero);
				}		
			}
		}
		#endif
	}

	void crearObjecto(int type, Vector3 pos)
	{	
		if (type == 0) 
		{
			Debug.Log ("COLOCAR CUBO");
		} 
		else if (type == 1) 
		{
			Debug.Log ("COLOCAR ESFERA");
		}
	}
}
