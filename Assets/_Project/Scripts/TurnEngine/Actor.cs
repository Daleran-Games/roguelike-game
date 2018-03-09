using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.TileEngine;

namespace DaleranGames.TurnEngine
{
    public abstract class Actor : MonoBehaviour, IActor
    {
        public Vector3Int Position;

        protected virtual void OnEnable()
        {
            TurnManager.AddTurnObject(this, true);
            Position = Map.Instance.Terrain.WorldToCell(transform.position);
        }

        protected virtual void OnDisable()
        {
            TurnManager.RemoveTurnObject(this);
        }

        public abstract IEnumerator Act();

    }
}