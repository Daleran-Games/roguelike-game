using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DaleranGames.TileEngine
{
    [CreateAssetMenu(fileName = "NewIslandTemplate", menuName = "Map/Template/Island", order = 380)]
    public class IslandTemplate : MapTemplate
    {
        [Header("Map Size")]
        public Vector2Int MapWidth = new Vector2Int(18, 22);
        public Vector2Int MapHeight = new Vector2Int(18, 22);

        [Header("Land")]
        public Vector2Int BorderSizes = new Vector2Int(6, 10);
        public TileBase BorderTile;
        public TileBase BorderBlank;
        public TileBase FillTile;

        public override void GenerateMap(out DataGrid<TileBase> tiles, out DataGrid<GameObject> objects, Vector3Int origin)
        {
            Vector2Int mapSize = new Vector2Int(Random.Int(MapWidth), Random.Int(MapHeight));
            BoundsInt mapBounds = new BoundsInt(origin, new Vector3Int(mapSize.x, mapSize.y, 2));
            tiles = new DataGrid<TileBase>(mapBounds);
            objects = new DataGrid<GameObject>(mapBounds);

            BoundsInt islandBounds = new BoundsInt(origin, new Vector3Int(mapSize.x, mapSize.y, 2));
            islandBounds.SetMinMax(new Vector3Int(islandBounds.xMin+ Random.Int(BorderSizes),islandBounds.yMin + Random.Int(BorderSizes), 0), new Vector3Int(islandBounds.xMax - Random.Int(BorderSizes), islandBounds.yMax - Random.Int(BorderSizes),1));

            if (BorderTile != null)
                DrawBox(BorderTile, tiles, mapBounds, 0, true,true);

            if (BorderBlank != null)
                DrawBox(BorderBlank, tiles, mapBounds, 1, false, true);

            if (FillTile != null)
                DrawBox(FillTile, tiles, islandBounds, 0, true, true);

        }

    }
}
