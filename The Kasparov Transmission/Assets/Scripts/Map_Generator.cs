using System.Collections;
using UnityEngine;

// Generates a variable, customisable size grid for a tile based map
public class Map_Generator : MonoBehaviour 
{
    public Transform trTilePrefab;
	public Transform[,] trTiles;

    void Awake()
    {
    }

    // Place tiles in a 2D Array and instantiate each tile using a quad prefab
    // Size is determined by values of v2MapSize
	public void GenerateMap(int iColCount, int iRowCount)
    {
		trTiles = new Transform[iColCount, iRowCount];
		for (int x = 0; x < iColCount; x++)
        {
			for (int y = 0; y < iRowCount; y++)
            {
				Vector3 v3TilePosition = new Vector3( ( ( -iColCount / 2.0f ) + 0.5f + x ), 0.0f, ( ( iRowCount / 2.0f ) + 0.5f - y ) );
				Transform trNewTile = Instantiate( trTilePrefab, v3TilePosition, Quaternion.Euler( Vector3.right * 90 ), this.transform ) as Transform;
				trTiles [y, x] = trNewTile;
			}
        }
    }
};