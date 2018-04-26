using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadCode : MonoBehaviour {

    private CodeSnippets codeSnippets;

    [Serializable]
    private class Snippet
    {
        public string name;
        public string code;
    }

    [Serializable]
    private class CodeSnippets
    {
        public Snippet[] snippets;
    }

    // Use this for initialization
    void Start () {
        codeSnippets = JsonUtility.FromJson<CodeSnippets>(File.ReadAllText("Assets/JSON/python-snippets.json"));
        Debug.Log(codeSnippets.snippets[0].code);
    }

    public void LoadCodeInto(InputField inputField)
    {
        inputField.text = codeSnippets.snippets[0].code;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
}


