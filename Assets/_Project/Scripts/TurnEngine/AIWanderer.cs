using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace DaleranGames.TurnEngine
{
    public class AIWanderer : Actor
    {

        MoveAction moveAction;

        Vector3Int[] directions = new Vector3Int[] { Vector3Int.right, Vector3Int.left, Vector3Int.up, Vector3Int.down };

        private void Awake()
        {
            moveAction = GetComponent<MoveAction>();
        }

        public override IEnumerator Act()
        {
            yield return new WaitWhile(() => DOTween.IsTweening(transform));

            Vector3Int move = Vector3Int.zero;
            bool skip = false;

            PickRandomDirection(out move, out skip);

            if (!skip)
            {
                Position += move;
                moveAction.Move(Position);
                
            }
            else
                transform.DOMove(transform.position, TurnManager.TurnSpeed);

            yield break;
        }

        void PickRandomDirection(out Vector3Int move, out bool skip)
        {
            skip = false;
            move = Vector3Int.zero;
            List<Vector3Int> moves = new List<Vector3Int>(directions);
            moves.Shuffle();

            for (int i=0; i < moves.Count; i++)
            {
                if (moveAction.IsValidMovePosition(Position + moves[i]))
                {
                    move = moves[i];
                    return;
                }
            }
            skip = true;

        }

    }
}