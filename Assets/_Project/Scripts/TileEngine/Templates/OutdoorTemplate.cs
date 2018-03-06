using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DaleranGames.TileEngine
{
    [CreateAssetMenu(fileName = "NewOutdoorTemplate", menuName = "Map/Template/Outdoor", order = 380)]
    public class OutdoorTemplate : MapTemplate
    {
        [Header("Map Size")]
        public Vector2Int MapWidth = new Vector2Int(18, 22);
        public Vector2Int MapHeight = new Vector2Int(18, 22);

        [Header("Border Tiles")]
        public TileBase NorthTile;
        public Vector2Int NorthSizeRange;
        public TileBase SouthTile;
        public Vector2Int SouthSizeRange;
        public TileBase EastTile;
        public Vector2Int EastSizeRange;
        public TileBase WestTile;
        public Vector2Int WestSizeRange;

        [Header("Fill Tiles")]
        public TileBase DirtTile;
        [Range(0f,1f)]
        public float DirtDensity = 0.5f;
        public TileBase[] VegetationTiles;
        [Range(0f, 1f)]
        public float VegetationDensity = 0.5f;

        [Header("Water Tiles")]
        public TileBase WaterTile;
        public Vector2Int NumberOfWaterFeatures;

        public override void GenerateMap(out DataGrid<TileBase> tiles, out DataGrid<GameObject> objects, Vector3Int origin)
        {
            Vector2Int mapSize = new Vector2Int(Random.Int(MapWidth), Random.Int(MapHeight));
            BoundsInt mapBounds = new BoundsInt(origin, new Vector3Int(mapSize.x, mapSize.y, 1));
            tiles = new DataGrid<TileBase>(mapBounds);
            objects = new DataGrid<GameObject>(mapBounds);

            if (NorthTile != null)
                DrawRandomBorder(NorthTile, ref tiles, NorthSizeRange,0, MapEdge.North);

            if (SouthTile != null)
                DrawRandomBorder(SouthTile, ref tiles, SouthSizeRange,0, MapEdge.South);

            if (EastTile != null)
                DrawRandomBorder(EastTile, ref tiles, EastSizeRange,0, MapEdge.East);

            if (WestTile != null)
                DrawRandomBorder(WestTile, ref tiles, WestSizeRange,0, MapEdge.West);

            if (DirtTile != null && DirtDensity > 0f)
                LayoutObjectsAtRandom(DirtTile, ref tiles, mapBounds,0, DirtDensity);

            if (DirtTile != null && DirtDensity > 0f)
                LayoutObjectsAtRandom(VegetationTiles, ref tiles, mapBounds,0, VegetationDensity);

        }

    }
}