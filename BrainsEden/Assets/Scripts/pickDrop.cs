using UnityEngine;
using System.Collections;
using UnityEngine.UI;				//clase Toggle
using UnityEngine.EventSystems;		//IsPointerOverGameObject-> comprueba si un input esta encima de otroGame object


public class pickDrop : MonoBehaviour {

	public Button botonCubo;
	public Button botonEsfera;
	public GameObject cruz;
	public GameObject iconSelec;
	
	private int objSeleccionado;
	private Image miniaturaDrag;
	
	//DEVELOPEMENT_BUILD
	public Text inputPos;
	public Text	textoSelec;
	
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

	GameObject CheckBox(Vector3 touchPosition)
	{
		Ray raycast = Camera.main.ScreenPointToRay (touchPosition);
		RaycastHit raycastHit;
		if(Physics.Raycast(raycast, out raycastHit, 100))
	   	{
			if(raycastHit.collider != null)
			{
				if(raycastHit.collider.gameObject.GetType().Equals("Box"))
				{
					return(raycastHit.collider.gameObject);
				}
			}
		}
		return(null);
	}

	void LateUpdate()
	{
		if(Input.touchCount > 0)
		{
			if(Input.touches[0].position.x > 97 && objSeleccionado!= -1)	//posicion en coordenadas de world
			{
				if(Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Stationary)
				{
					cruz.gameObject.transform.position= Input.touches[0].position;
					cruz.SetActive(true);
				}
				else if(Input.touches[0].phase == TouchPhase.Ended)
				{
					GameObject box = CheckBox(Input.touches[0].position);
					if(box != null)
					{
						Debug.Log(box.GetComponent<BoxScript>().id);
					}
					//crearObjecto(objSeleccionado, Input.touches[0].position);
					cruz.SetActive(false);
					iconSelec.SetActive(false);
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
		//seleccion boton
		if(objSeleccionado == objNum)
		{
			objSeleccionado= -1	;	
		}
		else
		{
			objSeleccionado= objNum;
		}
		
		//icono de seleccion
		if(objSeleccionado!= -1)
		{
			if(objSeleccionado== 0)
			{
				iconSelec.transform.position= botonCubo.gameObject.transform.position;
			}
			else if (objSeleccionado== 1)
			{
				iconSelec.transform.position= botonEsfera.gameObject.transform.position;
			}	
			iconSelec.SetActive(true);
		}
		else
		{
			iconSelec.SetActive(false);
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
