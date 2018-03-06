using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.TileEngine
{
    [System.Flags]
    public enum MapEdge
    {
        North = (1 << 0),
        East = (1 << 1),
        South = (1 << 2),
        West = (1 << 3)
    }
}

