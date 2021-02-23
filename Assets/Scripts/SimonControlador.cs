using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimonControlador : MonoBehaviour {
	public BotonScript[] botones;
	public List<int> aleatorio = new List<int>();

	bool lleno;
	public bool miturno, turnoComp;

	int cont=0, contUsuario=0, nivel=0; 

	// Use this for initialization
	void Start () {
		llenarAleatorio ();
		//nivel = 3;
		botones = new BotonScript[4];
		botones [0] = GameObject.Find ("1").GetComponent<BotonScript>();
		botones [1] = GameObject.Find ("2").GetComponent<BotonScript>();
		botones [2] = GameObject.Find ("3").GetComponent<BotonScript>();
		botones [3] = GameObject.Find ("4").GetComponent<BotonScript>();

		turnoComp = true;
		Invoke ("empezar",1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void llenarAleatorio() {
		for (int i = 0; i < 1000; i++) {
			aleatorio.Add (Random.Range(0,4));
			//Debug.Log ("i"+i+": "+aleatorio [i]);
		}
		lleno = true;
	}

	void turno() {
		if (turnoComp) {
			turnoComp = false;
			miturno = true;
		} else {
			turnoComp = true;
			miturno = false;
			cont = 0;
			contUsuario = 0;
			Invoke ("empezar", 1f);
		}
	}

	void empezar() {
		if(lleno && turnoComp) {
			botones [aleatorio [cont]].encender ();
			if (cont >= nivel) {
				nivel++;
				turno ();
			} else {
				cont++;
			}
			Invoke("empezar",1f);
		}
	}

	public void usuarioSeleccion(int id) {
		if (id != aleatorio [contUsuario]) {
			//termina
			GameObject.Find ("texto").GetComponent<Text> ().text = "Fallaste...";
			StartCoroutine (nuevo ());
			return;
		}
		if (contUsuario == cont) {
			// subir puntaje
			string p = ((nivel)*10).ToString();
			GameObject.Find ("puntaje").GetComponent<Text> ().text = p+" puntos";
			GameObject.Find ("texto").GetComponent<Text> ().text = "Bien!";
			turno ();
		} else {
			contUsuario++;
		}
	}

	IEnumerator nuevo(){
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene ("Juego");
	}
}
