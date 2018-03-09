using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DaleranGames.TurnEngine;

namespace DaleranGames.TileEngine
{
    public class TileCollider : MonoBehaviour
    {
        [SerializeField]
        [EnumFlags]
        CollisionType type;


        DataGrid<CollisionType> col;

        MoveAction mover;

        // Use this for initialization
        void Start()
        {
            col = Map.Instance.Collision;
            col.Add(Map.Instance.Terrain.WorldToCell(transform.position), type);
        }

        private void OnEnable()
        {
            mover = GetComponent<MoveAction>();
            if (mover != null)
                mover.Moved += OnMove;
        }

        private void OnDisable()
        {
            if (mover != null)
                mover.Moved -= OnMove;
        }

        void OnMove(Vector3Int lastPos, Vector3Int nextPos)
        {
            MapTile lastTile = Map.Instance.Terrain.GetTile<MapTile>(lastPos);

            if (lastTile != null)
                col[lastPos] = lastTile.Collision;
            else
                col[lastPos] = 0;

            col[nextPos] = type;
        }
        
        

    }
}