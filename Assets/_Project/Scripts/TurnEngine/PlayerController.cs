using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using DaleranGames.TileEngine;

namespace DaleranGames.TurnEngine
{
    public class PlayerController : Actor
    {
        MoveAction moveAction;

        private void Awake()
        {
            moveAction = GetComponent<MoveAction>();        
        }

        public override IEnumerator Act()
        {
            yield return new WaitWhile(() => DOTween.IsTweening(transform));

            Vector3Int move = Vector3Int.zero;
            bool skip = false;
            yield return new WaitUntil(() => HandleInput(out move, out skip));

            if (!skip)
            {
                Position += move;
                moveAction.Move(Position);
                
            } else
                transform.DOMove(transform.position, TurnManager.TurnSpeed);

            yield break;
        }

        bool HandleInput(out Vector3Int move, out bool skip)
        {
            int x = 0;
            int y = 0;
            skip = false;

            if (Input.GetKey(KeyCode.Space))
            {
                skip = true;
                move = Vector3Int.zero;
                return true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
                x = 1;
            else if (Input.GetKey(KeyCode.LeftArrow))
                x = -1;
            else if (Input.GetKey(KeyCode.UpArrow))
                y = 1;
            else if (Input.GetKey(KeyCode.DownArrow))
                y = -1;


            if (x != 0 || y != 0)
            {
                move = new Vector3Int(x, y, 0);
                if (moveAction.IsValidMovePosition(Position + move))
                    return true;
            }
            move = Vector3Int.zero;
            return false;

        }
    }
}
