using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;

public class ServerPlacement : MonoBehaviour {
    public Tilemap serverPlacementMap;
    public Sprite brokenServer;
    public Sprite fixedServer;

    public Tile hoverServerTile;
    public ServerTile brokenServerTile;

    private bool activePlacement;
    
    class TileMeta
    {
        public Vector3Int pos;
        public TileBase tile;

        public TileMeta(Vector3Int pos, TileBase tile)
        {
            this.pos = pos;
            this.tile = tile;
        }

        public bool Equals(TileMeta tileMeta)
        {
            return tileMeta.pos.x == this.pos.x && tileMeta.pos.y == this.pos.y && tileMeta.pos.z == this.pos.z;
        }

        public bool IsServerTile()
        {
            return tile is ServerTile;
        }
    }

    public class ServerTile : Tile
    {
        public bool serverDown = false;
    }

    private TileMeta last = null;

	// Use this for initialization
	void Start () {
        SpriteAtlas server = Resources.Load<SpriteAtlas>("Assets/Game Objects/Server Rack");
        //serverPlacementMap.SetTile(new Vector3Int(0, 0, 0), server);

        hoverServerTile = ScriptableObject.CreateInstance<Tile>();
        hoverServerTile.sprite = brokenServer;// server.GetSprite("Broken Server");

        brokenServerTile = ScriptableObject.CreateInstance<ServerTile>();
        brokenServerTile.sprite = brokenServer;// server.GetSprite("Broken Server");
    }

    public void OnMouseOver()
    {
        var v3 = Input.mousePosition;
        v3 = Camera.main.ScreenToWorldPoint(v3);

        var nearest = serverPlacementMap.WorldToCell(v3);
        var temp = new TileMeta(nearest, serverPlacementMap.GetTile(nearest));
        if (last == null)
        {
            last = temp;
            serverPlacementMap.SetTile(nearest, hoverServerTile);
        } else if (!last.Equals(temp)) {
            if (!last.IsServerTile())
                serverPlacementMap.SetTile(last.pos, last.tile);

            serverPlacementMap.SetTile(nearest, hoverServerTile);
            last = temp;
        }
    }

    public void OnMouseDown()
    {
        if (activePlacement)
        {
            var v3 = Input.mousePosition;
            v3 = Camera.main.ScreenToWorldPoint(v3);

            var nearest = serverPlacementMap.WorldToCell(v3);

            serverPlacementMap.SetTile(nearest, brokenServerTile);
            last = new TileMeta(nearest, brokenServerTile);
        }
    }

    public void SetActivePlacement(bool active)
    {
        activePlacement = active;
    }

    // Update is called once per frame
    void Update () {
        
    }
}
