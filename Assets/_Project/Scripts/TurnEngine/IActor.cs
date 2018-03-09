using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.TurnEngine
{
    public interface IActor
    {
        IEnumerator Act();
    }
}