using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour {

    public GameObject main;
    public GameObject options;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Return()
    {
        main.SetActive(true);
        options.SetActive(false);
    }
}
