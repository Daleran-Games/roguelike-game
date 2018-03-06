using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DaleranGames.TileEngine
{
    
    public abstract class MapTemplate : ScriptableObject
    {

        public abstract void GenerateMap(out DataGrid<TileBase> tiles, out DataGrid<GameObject> objects, Vector3Int origin);

        public static void DrawLine<T>(T item, ref T[,] grid, Vector2Int start, Vector2Int end, int thickness, bool overwrite = false)
        {

        }

        public static void DrawBox<T>(T item, ref T[,] grid, Vector2Int bottomLeft, Vector2Int topRight, bool fill = false, bool overwrite = false)
        {

        }

        public static void DrawCircle<T>(T item, ref T[,] grid, Vector2Int radii, Vector2Int center, bool fill = false, bool overwrite = false)
        {

        }

        public static void LayoutObjectsAtRandom<T>(T item, ref DataGrid<T> grid, BoundsInt bounds, int z, float chance, bool overwrite = false)
        {
            for (int y = bounds.yMin; y <= bounds.yMax; y++)
            {
                for (int x = bounds.xMin; x <= bounds.xMax; x++)
                {
                    if (Random.Bool(chance))
                        grid.Add(new Vector3Int(x, y, z), item, overwrite);
                }
            }
        }

        public static void LayoutObjectsAtRandom<T>(T[] items, ref DataGrid<T> grid, BoundsInt bounds, int z, float chance, bool overwrite = false)
        {
            for (int y = bounds.yMin; y <= bounds.yMax; y++)
            {
                for (int x = bounds.xMin; x <= bounds.xMax; x++)
                {
                    if (Random.Bool(chance))
                        grid.Add(new Vector3Int(x, y, z), items[items.RandomArrayIndex()], overwrite);
                }
            }
        }

        public static void LayoutObjectsAtRandom<T>(T[] items, ref T[,] grid, Vector2Int bottomLeft, Vector2Int topRight, int numberOfObjects, bool overwrite = false)
        {

        }

        public static void LayoutObjectsInPattern<T>(T[] items, ref T[,] grid, Vector2Int bottomLeft, Vector2Int topRight, Vector2Int pattern, bool overwrite = false)
        {

        }

        public static void DrawRandomBorder<T>(T border, ref DataGrid<T> grid, Vector2Int borderThickness, int z, MapEdge edges, bool overwrite = false)
        {
            if (edges.HasFlag(MapEdge.North))
            {
                int thickness = Random.Int(borderThickness);
                for (int x = grid.Bounds.xMin; x <= grid.Bounds.xMax; x++)
                {
                    for (int y = grid.Bounds.yMax - thickness; y <= grid.Bounds.yMax ; y++ )
                    {
                        grid.Add(new Vector3Int(x, y, z), border, overwrite);
                    }
                    thickness = ChangeThickness(thickness, borderThickness);
                }
            }

            if (edges.HasFlag(MapEdge.South))
            {
                int thickness = Random.Int(borderThickness);
                for (int x = grid.Bounds.xMin; x <= grid.Bounds.xMax; x++)
                {
                    for (int y = grid.Bounds.yMin + thickness; y >= grid.Bounds.yMin; y--)
                    {
                        grid.Add(new Vector3Int(x, y, 0), border, overwrite);
                    }
                    thickness = ChangeThickness(thickness, borderThickness);
                }
            }

            if (edges.HasFlag(MapEdge.East))
            {
                int thickness = Random.Int(borderThickness);
                for (int y = grid.Bounds.yMin; y <= grid.Bounds.yMax; y++)
                {
                    for (int x = grid.Bounds.xMax - thickness; x <= grid.Bounds.xMax; x++)
                    {
                        grid.Add(new Vector3Int(x, y, 0), border, overwrite);
                    }
                    thickness = ChangeThickness(thickness, borderThickness);
                }
            }

            if (edges.HasFlag(MapEdge.West))
            {
                int thickness = Random.Int(borderThickness);
                for (int y = grid.Bounds.yMin; y <= grid.Bounds.yMax; y++)
                {
                    for (int x = grid.Bounds.xMin + thickness; x >= grid.Bounds.xMin; x--)
                    {
                        grid.Add(new Vector3Int(x, y, 0), border, overwrite);
                    }
                    thickness = ChangeThickness(thickness, borderThickness);
                }
            }

        }

        static int ChangeThickness(int thickness, Vector2Int range)
        {
            if (Random.Bool())
            {
                if (Random.Bool())
                    thickness++;
                else
                    thickness--;

                thickness = Mathf.Clamp(thickness, range.x, range.y);
            }

            return thickness;
        }

        public static void DrawRoom<T>(T wall, T floor, Vector2Int bottomLeft, Vector2Int topRight, bool overwrite = false)
        {

        }

    }
}
