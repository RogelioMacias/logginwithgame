using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RequestManager : MonoBehaviour {

	public static RequestManager instance { get; private set;}

	void awake() {
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void consulta (string urs, string pss){
		StartCoroutine (request(urs,pss));
	}

	IEnumerator request(string urs, string pss){
		using (UnityWebRequest webRequest = UnityWebRequest.Get("https://raw.githubusercontent.com/Chezzar/PruebaUnityLogin/master/LoginUser"))
		{
			// Request and wait for the desired page.
			yield return webRequest.Send();

			if (webRequest.isError) {
				Debug.Log(": Error: " + webRequest.error);
				yield break;
			} else {
				//Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
			}

			Objeto jsn = JsonUtility.FromJson<Objeto>(webRequest.downloadHandler.text);

			//Debug.Log (jsn.user);
			if (jsn.password.Equals (pss) && jsn.password.Equals (pss)) {
				GameObject.Find ("label").GetComponent<Text> ().text = "Correcto";
				yield return new WaitForSeconds (1f);
				SceneManager.LoadScene ("Juego");
			} else {
				GameObject.Find ("label").GetComponent<Text> ().text = "Incorrecto";
			}
		}
	}
}
