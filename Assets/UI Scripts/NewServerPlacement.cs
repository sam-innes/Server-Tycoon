using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NewServerPlacement : MonoBehaviour {
    public Object hoverServerPrefab;
    public Object serverPrefab;
    private GameObject hoverUI; 

    void Awake()
    {
        CreateNew();
        SetActive(false);
    }

    public void CreateNew()
    {
        hoverUI = (GameObject)Instantiate(hoverServerPrefab);
    }

    public void OnMouseOver()
    {
        var v3 = Input.mousePosition;
        v3 = Camera.main.ScreenToWorldPoint(v3);

        hoverUI.transform.position = new Vector2(v3.x, v3.y);
    }

    public void OnMouseDown()
    {
        if (hoverUI.activeSelf && hoverUI.GetComponent<ServerScript>().InValidPosition())
        {
            Place();
            SetActive(false);
        }
    }

    public void Place()
    {
        GameObject newServer = (GameObject)Instantiate(serverPrefab);
        newServer.transform.position = hoverUI.transform.position;
    }

    public void SetActive(bool state)
    {
        hoverUI.SetActive(state);
    }

    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
    