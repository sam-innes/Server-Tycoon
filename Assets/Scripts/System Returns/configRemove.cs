using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class configRemove : MonoBehaviour {
	public Button button;
	void Start(){
		button.onClick.AddListener(GameObject.Find("Systems").GetComponent<scenes>().removeConfig);
	}
}
