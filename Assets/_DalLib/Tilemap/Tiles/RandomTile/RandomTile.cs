using System;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace UnityEngine.Tilemaps
{
	[Serializable]
	public class RandomTile : Tile
	{
        [Range(0f, 1f)]
        public float DetailChance = 0.5f;
		public Sprite[] Sprites;

		public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
		{
			base.GetTileData(location, tileMap, ref tileData);
			if ((Sprites != null) && (Sprites.Length > 0))
			{
                if (Random.value <= DetailChance)
                    tileData.sprite = Sprites[(int)(Sprites.Length * Random.value)];
                else
                    tileData.sprite = sprite;
			}
		}

#if UNITY_EDITOR
		[MenuItem("Assets/Create/Tiles and Brushes/Random Tile")]
		public static void CreateRandomTile()
		{
			string path = EditorUtility.SaveFilePanelInProject("Save Random Tile", "New Random Tile", "asset", "Save Random Tile", "Assets");

			if (path == "")
				return;

			AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<RandomTile>(), path);
		}
#endif
    }

    /*
#if UNITY_EDITOR
    [CustomEditor(typeof(RandomTile))]
    public class RandomTileEditor : Editor
    {
        private RandomTile tile { get { return (target as RandomTile); } }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            tile.m_DetailChance = EditorGUILayout.Slider("Detail Chance", tile.m_DetailChance, 0f, 1f);


            int count = EditorGUILayout.DelayedIntField("Number of Sprites", tile.m_Sprites != null ? tile.m_Sprites.Length : 0);
            if (count < 0)
                count = 0;
            if (tile.m_Sprites == null || tile.m_Sprites.Length != count)
            {
                Array.Resize<Sprite>(ref tile.m_Sprites, count);
            }

            if (count == 0)
                return;

            EditorGUILayout.LabelField("Place random sprites.");
            EditorGUILayout.Space();

            for (int i = 0; i < count; i++)
            {
                tile.m_Sprites[i] = (Sprite)EditorGUILayout.ObjectField("Sprite " + (i + 1), tile.m_Sprites[i], typeof(Sprite), false, null);
            }
            if (EditorGUI.EndChangeCheck())
                EditorUtility.SetDirty(tile);
        }
    }
#endif
*/
}
