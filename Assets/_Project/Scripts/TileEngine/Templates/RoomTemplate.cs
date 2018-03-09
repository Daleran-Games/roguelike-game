using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DaleranGames.TileEngine
{
    [CreateAssetMenu(fileName = "NewRoomTemplate", menuName = "Map/Template/Basic", order = 380)]
    public class RoomTemplate : MapTemplate
    {
        public override void GenerateMap(out DataGrid<MapTile> tiles, out DataGrid<GameObject> objects, Vector3Int origin)
        {
            throw new System.NotImplementedException();
        }
    }
}