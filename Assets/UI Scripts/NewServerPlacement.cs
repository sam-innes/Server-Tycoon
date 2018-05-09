using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NewServerPlacement : MonoBehaviour {
    public Sprite server;
    public Tilemap[] collisionMaps;
    public Object serverPrefab;
    GameObject hoverUI; 

    void Awake()
    {
        CreateNew();
        SetActive(false);
    }

    public void CreateNew()
    {
        hoverUI = (GameObject)Instantiate(serverPrefab);
    }

    public void OnMouseOver()
    {
        var v3 = Input.mousePosition;
        v3 = Camera.main.ScreenToWorldPoint(v3);

        hoverUI.transform.position = new Vector2(v3.x, v3.y);
    }

    public void OnMouseDown()
    {
        if (hoverUI.GetComponent<ServerScript>().InValidPosition())
        {
            Destroy(hoverUI.GetComponent<ServerScript>());
            hoverUI.GetComponent<BoxCollider2D>().isTrigger = false;
            CreateNew();
            SetActive(false);
        }
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
    