using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.TurnEngine
{
    public class TurnManager : MonoBehaviour
    {

        public static float TurnSpeed = 0.2f;
        static List<IActor> actors = new List<IActor>();

        bool inTurn = false;
        public bool InTurn { get { return inTurn; } }

        [SerializeField]
        int turn = 0;
        public int Turn { get { return turn; } }


        // Update is called once per frame
        void Update()
        {
            if (inTurn == false)
                StartCoroutine(CompleteTurn());
        }

        public IEnumerator CompleteTurn()
        {
            inTurn = true;
            for (int i=0;i<actors.Count;i++)
            {
                yield return StartCoroutine(actors[i].Act());
            }
            turn++;
            inTurn = false;
        }

        public static void AddTurnObject(IActor obj, bool priority = false)
        {
            if (priority)
                actors.Insert(0, obj);
            else
                actors.Add(obj);
        }

        public static void RemoveTurnObject(IActor obj)
        {
            actors.Remove(obj);
        }
    }
}

