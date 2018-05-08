using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenes : MonoBehaviour {
	void Start(){
		DontDestroyOnLoad(this.gameObject);
		SceneManager.SetActiveScene(SceneManager.GetSceneByName("game"));
	}

	public void loadEmail(){
		SceneManager.LoadScene("EmailClient", LoadSceneMode.Additive);
	}

	public void returnMain(){
		SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("EmailClient"));
		Debug.Log("test");
		GameObject.Find("manBlue_stand").GetComponent<playerController>().movementActivate();
	}

}
