using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.Transformers;
using TMPro;
using DaleranGames.TileEngine;

namespace DaleranGames.UI
{
    public class CoordinateText : MonoBehaviour
    {

        [SerializeField]
        TextMeshProUGUI text;
        [SerializeField]
        MouseGridFollower follower;

        private void OnEnable()
        {
            follower.Moved += UpdateText;   
        }

        private void OnDisable()
        {
            follower.Moved -= UpdateText;
        }

        void UpdateText(Vector3Int coord)
        {
            string update = "";

            if (Map.Instance.Terrain.GetTile(coord) != null)
                update += Map.Instance.Terrain.GetTile(coord).name + System.Environment.NewLine;

            if (Map.Instance.Terrain.cellBounds.Contains(coord))
                update += "Coord: " + coord.ToString() + System.Environment.NewLine;


            text.text = update;
        }

    }
}

