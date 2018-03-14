using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Concurrent;

namespace DaleranGames.TileEngine
{
    public class CollisionLayer : MapLayer, IGraph<Vector3Int>
    {
        ConcurrentDictionary<Vector3Int, CollisionType> map;

        public int Count { get { return map.Count; } }
        public const CollisionType EVERYTHING = CollisionType.Gas | CollisionType.Light | CollisionType.Movement | CollisionType.Over;
        public static readonly Vector3Int[] NEIGHBORS = new Vector3Int[]
        {
            new Vector3Int(1,0,0),
            new Vector3Int(0,-1,0),
            new Vector3Int(-1,0,0),
            new Vector3Int(0,1,0)

        };

        protected BoundsInt bounds;
        public BoundsInt Bounds { get { return bounds; } }

        public CollisionLayer(BoundsInt bounds)
        {
            this.bounds = bounds;
            map = new ConcurrentDictionary<Vector3Int, CollisionType>();
        }

        public CollisionType this[Vector3Int coord]
        {
            get
            {
                if (bounds.Contains(coord))
                {
                    CollisionType obj;
                    if (map.TryGetValue(coord, out obj))
                        return obj;
                    else
                        return 0;
                }
                else
                    return EVERYTHING;
            }

            set
            {
                Add(coord, value);
            }
        }

        public void Clear()
        {
            map.Clear();
            bounds = new BoundsInt();
        }

        public bool Add(Vector3Int coord, CollisionType collision)
        {
            if (bounds.Contains(coord))
            {
                if (map.TryAdd(coord, collision))
                {

                }
                map[coord] = collision;
                return true;
            }
            return false;
        }


        public int GetCost(Vector3Int start, Vector3Int end)
        {
            return 1;
        }

        public IEnumerable<Vector3Int> GetNeighbors(Vector3Int coord)
        {
            foreach (Vector3Int dir in NEIGHBORS)
            {
                Vector3Int next = coord + dir;
                if (!this[next].HasFlag(CollisionType.Movement))
                    yield return next;
            }
        }
    }
}
