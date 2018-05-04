using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenes : MonoBehaviour {

	void Start(){
		Debug.Log("test");
		Debug.Log(SceneManager.GetActiveScene());
	}
}
