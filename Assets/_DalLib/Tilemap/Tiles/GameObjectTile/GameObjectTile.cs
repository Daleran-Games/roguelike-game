using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityEngine
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "NewGameObjectTile", menuName = "Tiles and Brushes/GameObject Tile", order = 361)]
    public class GameObjectTile : TileBase
    {
        public GameObject Prefab;
        public OutputPrefab Output = OutputPrefab.Single;
        public enum OutputPrefab { Single, Random }

        public GameObject[] Prefabs;
        [Range(0.001f,0.999f)]
        public float PerlinScale = 0.5f;

        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {
            if (Output == OutputPrefab.Single)
                tileData.gameObject = Prefab;
            else
            {
                int index = Mathf.Clamp(Mathf.FloorToInt(GetPerlinValue(position, PerlinScale, 100000f) * Prefabs.Length), 0, Prefabs.Length - 1);
                tileData.gameObject = Prefabs[index];
            }
        }

        public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
        {
            go.transform.position += new Vector3(0.5f, 0.5f, 0);
            return true;
        }

        private static float GetPerlinValue(Vector3Int position, float scale, float offset)
        {
            return Mathf.PerlinNoise((position.x + offset) * scale, (position.y + offset) * scale);
        }

    }

}
