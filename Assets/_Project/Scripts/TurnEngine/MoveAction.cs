using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.TileEngine;
using DG.Tweening;

namespace DaleranGames.TurnEngine
{
    public class MoveAction : MonoBehaviour
    {
        public event System.Action<Vector3Int,Vector3Int> Moved;
        public Vector3Int LastPosition;

        private void Start()
        {
            LastPosition = Map.Instance.Terrain.WorldToCell(transform.position);
        }

        public void Move(Vector3Int to)
        {
            transform.DOMove(to, TurnManager.TurnSpeed);
            Moved?.Invoke(LastPosition,to);
            LastPosition = to;
        }

        public bool IsValidMovePosition(Vector3Int pos)
        {
            if (Map.Instance.Collision[pos].HasFlag(CollisionType.Movement))
                return false;
            else
                return true;
        }

    }
}

