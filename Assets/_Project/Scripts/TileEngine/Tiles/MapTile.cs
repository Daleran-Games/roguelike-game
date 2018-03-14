using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

#if UNITY_EDITOR
using UnityEditor;
#endif

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
        [EnumFlags]
        CollisionType collision;
        public CollisionType Collision { get { return collision; } }

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
            
        }

        public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
        {
            Map.Instance.Collision[position] = collision;

            if (go != null)
                go.transform.position += new Vector3(0.5f, 0.5f, 0);

            return true;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(MapTile))]
    public class MapTileEditor : Editor
    {
        private MapTile tile { get { return (target as MapTile); } }

        public override void OnInspectorGUI()
        {

            DrawDefaultInspector();
        }
        

        public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
        {
            if (tile.Sprite != null)
            {
                return tile.Sprite.ToTexture2D(tile.Albedo,width, height);
            }

            return null;
        }
    }
#endif
}

