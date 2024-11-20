using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ConstructPointGenerator : MonoBehaviour
{
    public Tilemap constructTile;
    public GameObject constructPointPrefab;

    private void Start()
    {
        foreach(var pos in constructTile.cellBounds.allPositionsWithin)
        {
            if(!constructTile.HasTile(pos)) continue;

            Vector3 realPos = pos + new Vector3(0.5f, 0.75f, 0);

            Instantiate(constructPointPrefab, realPos, Quaternion.identity, constructTile.transform);
        }
    }
}
