using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public bool isMoving = false;
    public GameObject goDetectUnwalkable;
    public Grid gGrid;
    public Node[,] naGrid;
	public Vector3 v3MovementDirection;
	public float fMovementSpeed = 5.0f;

	float fMovementDistance = 0.0f;
	List<GameObject> lgoMovingBots;


	// Use this for initialization
	void Awake () 
    {
        goDetectUnwalkable = GameObject.FindGameObjectWithTag("Pathing");
        gGrid = goDetectUnwalkable.GetComponent<Grid>();
		lgoMovingBots = new List<GameObject> ();
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
			float fMovementPerFrame = fMovementSpeed * Time.deltaTime;



			if ( fMovementDistance + fMovementPerFrame > 1.0f) {
				fMovementPerFrame =  1.0f - fMovementDistance;
				fMovementDistance = 1.0f;
			} 
			else 
			{
				fMovementDistance += fMovementPerFrame;
			}

			foreach(var goBot in lgoMovingBots)
			{
				goBot.transform.position += fMovementPerFrame * v3MovementDirection;
			}

			if (fMovementDistance == 1.0f)
			{
				fMovementDistance = 0.0f;
				isMoving = false;
				lgoMovingBots.Clear ();
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
			if ( Input.GetKeyDown( apszMovementKeys[iLoop].ToString() ) )
			{
				//Get list of 'Bot' children & Get the reordered list by direction
				GroupMovement cGMovementComp = gameObject.GetComponent<GroupMovement>();
				GameObject[] agoSortedBots 
						= cGMovementComp.GetGroupMovementList( GetChildren(), GroupMovement.ConvertV3ToDirection( av3MovementDirections[iLoop] ) );

				//GroupMovement.PrintGroup( agoSortedBots );
				//Check grid space against each sorted bot in the group and translate.
				foreach ( GameObject goSortedBot in agoSortedBots ) 
				{
					if ( gGrid.CheckGridSpace( goSortedBot.transform.position, av3MovementDirections[iLoop] ) == true )
					{
						goSortedBot.transform.Translate( av3MovementDirections[iLoop] );
						lgoMovingBots.Add (goSortedBot);
					}
					/*else 
					{
						Debug.Log(goSortedBot.name + " cannot move there!");
					}*/
				}
				if (lgoMovingBots.Count > 0)
				{
					v3MovementDirection = av3MovementDirections[iLoop];
					// Very bad implementation
					foreach(var goBot in lgoMovingBots)
					{
						goBot.transform.position -= v3MovementDirection;
					}
					isMoving = true;
					//lgoMovingBots.Clear ();
				}
				//Break as we only want to be able to move 1 direction per update.
				break;
			}
		}
	}

	//Get all the level 1 children of this object's transform.
	List<GameObject> GetChildren() 
	{
		List<GameObject> agoChildren = new List<GameObject>();
		foreach (Transform child in transform) 
		{
			agoChildren.Add( child.gameObject );
		}
		return agoChildren;
	}

	public void HoleReached(){

	}
}
