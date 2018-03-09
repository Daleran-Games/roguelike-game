using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



namespace DaleranGames.TileEngine
{
    public static class TilePhysics
    {
        public static int ManhattenDistance(this Vector3Int origin, Vector3Int point)
        {
            return Math.Abs(point.x - origin.x) + Math.Abs(point.y - origin.y);
        }

        public static bool Raycast(Vector3Int origin, Vector3Int point, int typeMask)
        {
            Vector3Int ray = point - origin;
            Vector3Int length = new Vector3Int(Math.Abs(ray.x), Math.Abs(ray.y), Math.Abs(ray.z));

            if (length.x < length.y)
            {
                length = new Vector3Int(length.y, length.x, length.z);
            }

        }
    }
}

