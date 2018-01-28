using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public LayerMask lmUnwalkableMask;
    public Vector2 v2GridWorldSize;
    public float fNodeRadius;

	[HideInInspector]
    public Node[,] naGrid;

	[HideInInspector]
	public Vector3[,] trTiles;

    float fNodeDiameter;
    int iGridSizeX;
    int iGridSizeY;

    void Start()
    {
        
    }

    public bool CheckGridSpace(Vector3 v3Position, Vector3 v3Check)
    {
        Vector3 v3CheckGrid = v3Position + v3Check;

		//Unused values.
		//Vector3 v3WorldBottomLeft = transform.position - ( Vector3.right * v2GridWorldSize.x / 2.0f ) - ( Vector3.forward * v2GridWorldSize.y / 2.0f );
		//Vector3 v3WorldPoint = v3WorldBottomLeft + Vector3.right * ( v3Position.x * fNodeDiameter + fNodeRadius ) + Vector3.forward * ( v3Position.y * fNodeDiameter + fNodeRadius );
		//int v3CheckGridX = Mathf.RoundToInt(v3Position.x + v3Check.x);
		//int v3CheckGridY = Mathf.RoundToInt(v3Position.z + v3Check.z);

		bool bWalkable = !(Physics.CheckSphere(v3CheckGrid, (fNodeRadius - 0.05f), lmUnwalkableMask));

        return bWalkable;
    }

	public void CreateGrid(int iColCount, int iRowCount)
    {
		fNodeDiameter   = fNodeRadius * 2.0f;
		iGridSizeX      = Mathf.RoundToInt(iColCount / fNodeDiameter);
		iGridSizeY      = Mathf.RoundToInt(iRowCount / fNodeDiameter);

        naGrid = new Node[iGridSizeX, iGridSizeY];
		trTiles = new Vector3[iRowCount, iColCount];

        Vector3 v3WorldBottomLeft = transform.position - ( Vector3.right * v2GridWorldSize.x / 2 ) - ( Vector3.forward * v2GridWorldSize.y / 2 );

        for (int x = 0; x < iGridSizeX; x++)
        {
            for (int y = 0; y < iGridSizeY; y++)
            {
                Vector3 v3WorldPoint = v3WorldBottomLeft + Vector3.right * ( x * fNodeDiameter + fNodeRadius ) + Vector3.forward * ( y * fNodeDiameter + fNodeRadius );
                bool bWalkable = !(Physics.CheckSphere(v3WorldPoint, (fNodeRadius - 0.05f), lmUnwalkableMask));
                naGrid[x, y] = new Node( bWalkable, v3WorldPoint );
				//Create placeholder position
				trTiles [y, x] = new Vector3( ( ( -iRowCount / 2.0f ) + 0.5f + y ), 0.0f,  ( ( iColCount / 2.0f ) + 0.5f - x ));

				//Logging function to show each grid space was created.
                //Debug.Log( "Node at " + x + ", " + y );
            }
        }
    }

    // Translates the world space into a grid co-ordinate so that the player can be found at a grid space
    public Node nNodeFromWorldPoint(Vector3 v3WorldPosition)
    {
        float fPercentX = ( v3WorldPosition.x + v2GridWorldSize.x / 2 ) / v2GridWorldSize.x;
        float fPercentY = ( v3WorldPosition.z + v2GridWorldSize.y / 2 ) / v2GridWorldSize.y;

        fPercentX       = Mathf.Clamp01( fPercentX );
        fPercentY       = Mathf.Clamp01( fPercentY );

        int x           = Mathf.RoundToInt( ( iGridSizeX - 1 ) * fPercentX );
        int y           = Mathf.RoundToInt( ( iGridSizeY - 1 ) * fPercentY );
        return naGrid[x, y];
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube( transform.position, new Vector3( v2GridWorldSize.x, 1, v2GridWorldSize.y ) );

        if (naGrid != null)
        {
            foreach (Node n in naGrid) 
            {
                Gizmos.color = (n.bWalkable) ? Color.white : Color.red;
                Gizmos.DrawCube( n.v3WorldPosition, Vector3.one * ( fNodeDiameter - 0.05f ) );
            }
        }
    }
}
