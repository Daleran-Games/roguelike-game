﻿using System.Collections;
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

        // Needs to be tested with edge cases
        public static bool Raycast(Vector3Int origin, Vector3Int direction, float distance, Func<Vector3Int, bool> blocksRay, Action<Vector3Int> processTile)
        {
            Vector3Int ray = direction - origin;
            Vector3Int length = new Vector3Int(Math.Abs(ray.x), Math.Abs(ray.y), Math.Abs(ray.z));
            Vector3Int increment = new Vector3Int(Math.Sign(ray.x),Math.Sign(ray.y)<<16,0);
            int index = (origin.y << 16) + origin.x;

            if (length.x < length.y)
            {
                length = new Vector3Int(length.y, length.x, length.z);
                increment = new Vector3Int(increment.y, increment.x, increment.z);
            }

            int errorIncrement = length.y *2;
            int error = -length.x;
            int errorReset = length.x * 2;

            while(--length.x >= 0)
            {
                index += increment.x;
                error += errorIncrement;

                if (error > 0)
                {
                    error -= errorReset;
                    index += increment.y;
                }

                Vector3Int current = new Vector3Int(index & 0xFFFF, index >> 16, 0);

                if (distance >= 0 && Vector3Int.Distance(origin, current) > distance)
                    break;

                processTile(current);

                if (blocksRay(current))
                    return false;
            }
            return true;
        }

        

    }
}

