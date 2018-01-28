using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public bool isMoving = false;
	public bool isTurning = false;
    //public GameObject goDetectUnwalkable;
    public Grid gGrid;
    public Node[,] naGrid;
	public Vector3 v3MovementDirection;
	private float fMovementSpeed = 2.0f;

	float fMovementDistance = 0.0f;
	float fTurnDuration = 0.7f;
	Vector3 v3fLookDiretion;
	List<GameObject> lgoMovingBots;


	// Use this for initialization
	void Awake () 
    {
        //goDetectUnwalkable = GameObject.FindGameObjectWithTag("Pathing");
		gGrid = GameObject.FindGameObjectWithTag("Pathing").GetComponent<Grid>();
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
			// Everything bellow is 6 am coding without sleep
			// Turning logic
			if (isTurning) 
			{
				if (fTurnDuration > 0.0f) 
				{
					fTurnDuration -= Time.deltaTime;	
					foreach(var goBot in lgoMovingBots)
					{
						var newRotation = Vector3.RotateTowards( goBot.transform.forward, v3fLookDiretion, 90.0f * Time.deltaTime, 0.0f);
						goBot.transform.rotation = Quaternion.LookRotation (newRotation);
					}
				} 
				else
				{
					fTurnDuration = 0.7f;
					isTurning = false;
					foreach(var goBot in lgoMovingBots)
					{
						goBot.GetComponent<Animator> ().SetTrigger ("Run");
					}
				}

				return;
			}

			// Turning logic
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
				foreach(var goBot in lgoMovingBots)
				{
					goBot.GetComponent<Animator> ().SetTrigger ("Idle");
				}
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
			if ( Input.GetKey( apszMovementKeys[iLoop].ToString() ) )
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
						goSortedBot.transform.position += av3MovementDirections[iLoop];
						lgoMovingBots.Add (goSortedBot);
						
						//The point here and below is that we will change the color of the bots
						//to indicate if they accepted the command to move.
						//goSortedBot.GetComponent<MeshRenderer> ().materials[0].color = Color.green;
					}
					else 
					{
						//Debug.Log(goSortedBot.name + " cannot move there!");
						//goSortedBot.GetComponent<MeshRenderer> ().materials[0].color = Color.red;
					}				}
				if (lgoMovingBots.Count > 0)
				{
					v3fLookDiretion = av3MovementDirections[iLoop];
					v3MovementDirection = av3MovementDirections[iLoop];
					// Very bad implementation
					foreach(var goBot in lgoMovingBots)
					{
						goBot.transform.position -= av3MovementDirections[iLoop];
						goBot.GetComponent<Animator> ().SetTrigger ("Turn");
					}
					isMoving = true;
					isTurning = true;
				}

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
