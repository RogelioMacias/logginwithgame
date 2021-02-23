using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonScript : MonoBehaviour {
	public int idBoton;
	private Image btnCmp;
	private bool activo;
	private bool activando;
	private Color aux;
	private SimonControlador controlador;

	// Use this for initialization
	void Start () {
		btnCmp = gameObject.GetComponent<Image> ();
		gameObject.GetComponent<Button> ().onClick.AddListener (presiona); 
		controlador = GameObject.Find ("controlador").GetComponent<SimonControlador> ();
		aux = btnCmp.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void encender() {
		activo = true;
		activando = true;

		btnCmp.color = Color.magenta;
		StartCoroutine (apagar());
	}

	IEnumerator apagar(){
		yield return new WaitForSeconds (0.3f);
		btnCmp.color = aux; 
	}

	/*IEnumerator encender() {
		
	}*/

	void presiona() {
		if (controlador.miturno) {
			encender ();
			controlador.usuarioSeleccion (idBoton);

		}

	}


}
