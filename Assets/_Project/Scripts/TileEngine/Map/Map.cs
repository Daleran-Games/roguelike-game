using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DaleranGames.TileEngine
{

    public class Map : Singleton<Map>
    {

        [Header("Map Generation")]
        public MapTemplate Template;

        [Header("Map Layers")]
        public Tilemap Terrain;
        

        // Update is called once per frame
        void Awake()
        {
            GenerateMap();
        }

        [ContextMenu("Generate Map")]
        public void GenerateMap()
        {
            ClearMap();
            DataGrid<GameObject> objects;
            DataGrid < TileBase> tiles;
            Template.GenerateMap(out tiles,out objects, Vector3Int.zero);
            Terrain.SetTiles(tiles.Positions, tiles.Values);
        }

        [ContextMenu("Clear Map")]
        public void ClearMap()
        {
            Terrain?.ClearAllTiles();
        }


    }
}
