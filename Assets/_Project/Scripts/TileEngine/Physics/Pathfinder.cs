using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using Priority_Queue;
using System.Threading.Tasks;

namespace DaleranGames.TileEngine
{
    public class Pathfinder
    {
        volatile bool isDone = false;
        public bool IsDone { get { return isDone; } }
        public List<Vector3Int> Path { get; private set; }

        // Note: a generic version of A* would abstract over Vector3Int and
        // also Heuristic
        static public float Heuristic(Vector3Int a, Vector3Int b)
        {
            return Math.Abs(a.x - b.x) + Math.Abs(a.y - b.y);
        }

        public Pathfinder(IGraph<Vector3Int> graph, Vector3Int start, Vector3Int goal)
        {
            isDone = false;


            var t = Task.Run(() => GetPath(graph, start, goal));
            Path = t.Result;
            isDone = true;
        }

       List<Vector3Int> GetPath(IGraph<Vector3Int> graph, Vector3Int start, Vector3Int goal)
        {
            Dictionary<Vector3Int, Vector3Int> cameFrom = new Dictionary<Vector3Int, Vector3Int>();
            Dictionary<Vector3Int, float> costSoFar = new Dictionary<Vector3Int, float>();

            var frontier = new SimplePriorityQueue<Vector3Int>();
            frontier.Enqueue(start, 0);
            var found = false;

            cameFrom[start] = start;
            costSoFar[start] = 0;

            while (frontier.Count > 0)
            {
                var current = frontier.Dequeue();

                if (current.Equals(goal))
                {
                    found = true;
                    break;
                }

                foreach (var next in graph.GetNeighbors(current))
                {
                    float newCost = costSoFar[current] + graph.GetCost(current, next);
                    if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                    {
                        costSoFar[next] = newCost;
                        float priority = newCost + Heuristic(next, goal);
                        frontier.Enqueue(next, priority);
                        cameFrom[next] = current;
                    }
                }
            }

            return TracePath(cameFrom, start, goal, found);
        }

        List<Vector3Int> TracePath (Dictionary<Vector3Int, Vector3Int> cameFrom, Vector3Int start, Vector3Int goal, bool found)
        {
            List<Vector3Int> path = new List<Vector3Int>();
            Vector3Int trace;

            if (found)
                trace = goal;
            else
                trace = FindClosest(cameFrom, start, goal);

            while (trace != start)
            {
                path.Add(trace);

                if (trace == start)
                    break;

                trace = cameFrom[trace];
            }
            path.Reverse();

            return path;
        }

        Vector3Int FindClosest(Dictionary<Vector3Int, Vector3Int> cameFrom, Vector3Int start, Vector3Int goal)
        {
            Vector3Int closest = start;

            foreach (Vector3Int k in cameFrom.Keys)
            {
                if (k.ManhattenDistance(goal) < closest.ManhattenDistance(goal))
                    closest = k;
            }

            return closest;
        }


    }
}

