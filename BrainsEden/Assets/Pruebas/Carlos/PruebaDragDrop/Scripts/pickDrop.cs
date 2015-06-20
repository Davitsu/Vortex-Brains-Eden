using UnityEngine;
using System.Collections;
using UnityEngine.UI;				//clase Toggle
using UnityEngine.EventSystems;		//IsPointerOverGameObject-> comprueba si un input esta encima de otroGame object


public class pickDrop : MonoBehaviour {

	public Button botonCubo;
	public Button botonEsfera;
	public GameObject cruz;
	
	//DEVELOPEMENT_BUILD
	public Text inputPos;
	public Text	textoSelec;
	
	private int objSeleccionado;
	
	void Awake(){
		Input.multiTouchEnabled = false;
	}

	// Use this for initialization
	void Start () {
		objSeleccionado= -1;
		#if DEVELOPMENT_BUILD
		inputPos.gameObject.SetActive(true);
		textoSelec.gameObject.SetActive(true);
		#endif
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	void LateUpdate()
	{
		if(Input.touchCount > 0)
		{
			if(Input.touches[0].position.x > 97 && objSeleccionado!= -1)	//posicion en coordenadas de world
			{
				if(Input.touches[0].phase == TouchPhase.Began )	
				{
					
				}
				else if(Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Stationary)
				{
					cruz.gameObject.transform.position= Input.touches[0].position;
					cruz.SetActive(true);
				}
				else if(Input.touches[0].phase == TouchPhase.Ended)
				{
					crearObjecto(objSeleccionado, Input.touches[0].position);
					cruz.SetActive(false);
				}
				#if DEVELOPMENT_BUILD
				inputPos.text= Input.touches[0].position.x.ToString() + " , " + Input.touches[0].position.y.ToString();
				#endif
			}
			else
			{
				cruz.SetActive(false);
				#if DEVELOPMENT_BUILD
				inputPos.text= "N/A";
				#endif
			}
		}
		else
		{
			cruz.SetActive(false);
			#if DEVELOPMENT_BUILD
			inputPos.text= "N/A";
			#endif
		}
		#if DEVELOPMENT_BUILD
		if(objSeleccionado == -1)
		{
			textoSelec.text="Seleccion: N/A";
		}
		else
		{
			textoSelec.text="Seleccion: " + objSeleccionado;
		}
		#endif
	}
	
	public void BotonApretado(int objNum)
	{
		if(objSeleccionado == objNum)
		{
			objSeleccionado= -1	;	
		}
		else
		{
			objSeleccionado= objNum;
		}
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
		objSeleccionado= -1;
	}
}
