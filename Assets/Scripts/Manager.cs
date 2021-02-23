using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {
	private Button enviarBtn;
	// Use this for initialization
	void Start () {
		enviarBtn = GameObject.Find ("enter").GetComponent<Button>();
		enviarBtn.onClick.AddListener (accionEnviar);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void accionEnviar() {
		string usuario = GameObject.Find ("usuario").GetComponent<InputField>().text;
		string contrasenia = GameObject.Find ("pass").GetComponent<InputField>().text;

		RequestManager.instance.consulta (usuario, contrasenia);
			
			
	}
}
