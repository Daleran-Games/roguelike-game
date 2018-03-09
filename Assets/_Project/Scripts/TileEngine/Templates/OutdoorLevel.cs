using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DaleranGames.TileEngine
{
    [CreateAssetMenu(fileName = "NewOutdoorLevel", menuName = "Map/Level/Outdoor", order = 370)]
    public class OutdoorLevel : MapTemplate
    {
        public OutdoorTemplate Outdoor;

        public override void GenerateMap(out DataGrid<MapTile> tiles, out DataGrid<GameObject> objects, Vector3Int origin)
        {
            Outdoor.GenerateMap(out tiles, out objects, origin);
        }
    }
}