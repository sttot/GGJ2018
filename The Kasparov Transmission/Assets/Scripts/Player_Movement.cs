using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public bool isMoving = false;

    public GameObject goDetectUnwalkable;
    public Grid gGrid;
    public Node[,] naGrid;
	public Vector3 v3TargetNode;
	public float fMovementSpeed = 5.0f;

	// Use this for initialization
	void Awake () 
    {
        goDetectUnwalkable = GameObject.FindGameObjectWithTag("Pathing");
        gGrid = goDetectUnwalkable.GetComponent<Grid>();
	}

    // Use this to check the relevant grid the player wants to move to
    // If there is a wall, don't move the player
    // Use the Unwalkable layer to check
	// N.B not implemented yet.
    bool CheckGrid(Transform tTransform, Vector3 v3Check)
    {
        return true;
    }

	// Update is called once per frame
	void Update () 
    {
        // If no key is pressed, check if there is any movement
        // If no movement, can move by pressing key
        // Movement Controls
		if (!isMoving) 
		{
			ProcessInputKeys ();
		} 
		else 
		{
			transform.position = Vector3.MoveTowards (transform.position, v3TargetNode, fMovementSpeed * Time.deltaTime);
			if (transform.position == v3TargetNode)
			{
				isMoving = false;
			}
		}
	}

	// Check all for direction movement keys and apply the corresponding movement.
	void ProcessInputKeys() 
	{
		char[] apszMovementKeys = { 'w', 's', 'a', 'd' };
		Vector3[] av3MovementDirections = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
		for ( int iLoop = 0; iLoop < apszMovementKeys.Length; ++iLoop ) 
		{
			if ( Input.GetKey( apszMovementKeys[iLoop].ToString() ) )
			{
				if ( gGrid.CheckGridSpace( transform.position, av3MovementDirections[iLoop] ) == true )
				{
					var currentPosition = transform.position;
					v3TargetNode = transform.position + av3MovementDirections[iLoop];
					isMoving = true;
				}
			}
		}
	}
}
