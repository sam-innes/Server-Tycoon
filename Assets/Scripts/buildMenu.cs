using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildMenu : MonoBehaviour {

	public GameObject open;
	public GameObject menu;

	public GameObject serverPlacement;

	public bool trigger;

	void Start(){
		trigger = false;
		open.SetActive(true);
		menu.SetActive(false);
	}

	public void toggleMenu(){
		open.SetActive(trigger);
		menu.SetActive(!trigger);

		setActive();

		trigger = !trigger;
	}

	public void setActive(){
		serverPlacement.GetComponent<ServerPlacement>().showBlock(!trigger);
	}
}
