using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.TileEngine
{
    public interface IGraph<T>
    {
        IEnumerable<T> GetNeighbors(T coord);
        int GetCost(T start,T end);
    }
}

