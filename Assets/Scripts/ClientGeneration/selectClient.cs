using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectClient : MonoBehaviour {
	public GameObject self;

	void OnMouseEnter(){
		Debug.Log("Reached");
		if(Input.GetMouseButtonDown(0)){
       Debug.Log("test");
    }
	}



}
