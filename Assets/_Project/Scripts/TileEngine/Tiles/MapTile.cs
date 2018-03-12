using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DaleranGames.TileEngine
{
    [CreateAssetMenu(fileName = "NewMapTile", menuName = "Tiles and Brushes/Map Tile", order = 365)]
    public class MapTile : TileBase
    {
        [Header("Main")]
        [SerializeField]
        Sprite sprite;
        public Sprite Sprite { get { return sprite; } }

        [SerializeField]
        Color albedo = Color.white;
        public Color Albedo { get { return albedo; } }

        [SerializeField]
        GameObject prefab;
        public GameObject Prefab { get { return prefab; } }

        [SerializeField]
        Tile.ColliderType colliderType;
        public Tile.ColliderType ColliderType { get { return colliderType; } }

        [Header("Details")]
        [Range(0f, 1f)]
        public float DetailChance = 0.5f;
        public Sprite[] Details;

        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {
            if (sprite != null)
            {
                tileData.sprite = sprite;
            }

            if ((Details != null) && (Details.Length > 0))
            {
                if (Random.Bool(DetailChance))
                    tileData.sprite = Details[(int)(Details.Length * Random.Float01())];
                else
                    tileData.sprite = sprite;
            }

            if (prefab != null)
                tileData.gameObject = prefab;

            tileData.color = albedo;
            tileData.transform = Matrix4x4.identity;
            tileData.flags = TileFlags.None;
            tileData.colliderType = ColliderType;
            
        }

        public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
        {

            if (go != null)
                go.transform.position += new Vector3(0.5f, 0.5f, 0);

            return true;
        }


    }
}

