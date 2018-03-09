using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.TileEngine
{
    [System.Flags]
    public enum CollisionType
    {
        Movement = (1 << 0),
        Over = (1 << 1),
        Light = (1 << 2),
        Gas = (1 << 3)
    }
}
