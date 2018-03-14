using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.TileEngine;

public class PathfinderTester : MonoBehaviour {

    [SerializeField]
    Vector3Int start;
    [SerializeField]
    Vector3Int end;


    [SerializeField]
    List<Vector3Int> path;

    CollisionLayer layer;

    // Use this for initialization
	void Start ()
    {
        layer = Map.Instance.Collision;
	}

    [ContextMenu("Generate Path")]
    public void TestPath()
    {
        
        StopAllCoroutines();
        StartCoroutine(Path());
    }

    IEnumerator Path()
    {
        Pathfinder newPath = new Pathfinder(layer, start, end);
        yield return new WaitUntil(() => newPath.IsDone);
        path = newPath.Path;
    }

	
}
