using System.Collections;
using UnityEngine;

// Generates a variable, customisable size grid for a tile based map
public class Map_Generator : MonoBehaviour 
{
    public Transform trTilePrefab;
    public Vector2 v2MapSize;

    void Awake()
    {
        //GenerateMap();
    }

    // Place tiles in a 2D Array and instantiate each tile using a quad prefab
    // Size is determined by values of v2MapSize
    public void GenerateMap()
    {
        for (int x = 0; x < v2MapSize.x; x++)
        {
            for (int y = 0; x < v2MapSize.y; y++)
            {
               // Vector3 v3TilePosition = new Vector3( ( ( -v2MapSize.x / 2.0f ) + 0.5f + x ), 0.0f, ( ( -v2MapSize.y / 2.0f ) + 0.5f + y ) );
                //Transform trNewTile = Instantiate( trTilePrefab, v3TilePosition, Quaternion.Euler( Vector3.right * 90 ) ) as Transform;
            }
        }
    }
};