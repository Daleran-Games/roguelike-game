using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.TileEngine;
using DG.Tweening;

namespace DaleranGames.TurnEngine
{
    public class AIChaser : Actor
    {
        PlayerController player;

        [SerializeField]
        Vector3Int closest;

        [SerializeField]
        List<Vector3Int> path;
        Vector3Int target;
        MoveAction moveAction;

        private void Awake()
        {
            moveAction = GetComponent<MoveAction>();
        }

        // Use this for initialization
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        public override IEnumerator Act()
        {
            closest = GetClosestAdjacentPosition();

            if (closest != Position)
            {
                Pathfinder newPath = new Pathfinder(Map.Instance.Collision, Position, closest);
                yield return new WaitWhile(() => DOTween.IsTweening(transform));
                yield return new WaitUntil(() => newPath.IsDone);
                path = newPath.Path;

                if (path.Count > 0)
                {
                    Position = path[0];
                    moveAction.Move(Position);
                }
                else
                    transform.DOMove(transform.position, TurnManager.TurnSpeed);
            } else
            {
                transform.DOMove(transform.position, TurnManager.TurnSpeed);
            }

            yield break;
        }

        Vector3Int GetClosestAdjacentPosition()
        {
            Vector3Int target = Map.Instance.Terrain.WorldToCell(player.Position);

            if (Position.ManhattenDistance(target) <= 1)
                return Position;

            List<Vector3Int> validPosition = new List<Vector3Int>();
            Vector3Int closest = new Vector3Int(10000, 10000, 0);
            bool found = false;

            for (int j = 1; j <= 10; j++)
            {
                for (int i = 0; i < TilePhysics.Directions.Length; i++)
                {
                    Vector3Int current = target + TilePhysics.Directions[i]*j;
                    if (!Map.Instance.Collision[current].HasFlag(CollisionType.Movement) && Position.ManhattenDistance(current) <= Position.ManhattenDistance(current))
                    {
                        closest = current;
                        found = true;
                    }
                }
                if (found)
                    break;
            }

            if (found)
                return closest;
            else
                return target;

        }
    }
}

