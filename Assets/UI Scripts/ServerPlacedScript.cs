using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerPlacedScript : MonoBehaviour {

    public Text Prompt;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Prompt.text = "Press 'e' to configure server";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Prompt.text = "";
    }

    // Update is called once per frame
    void Update () {
		
	}
}
