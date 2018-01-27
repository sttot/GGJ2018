using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public bool isMoving = false;

    public GameObject goDetectUnwalkable;
    public Grid gGrid;
    public Node[,] naGrid;

	// Use this for initialization
	void Awake () 
    {
        goDetectUnwalkable = GameObject.FindGameObjectWithTag("Pathing");
        gGrid = goDetectUnwalkable.GetComponent<Grid>();
	}

    // Use this to check the relevant grid the player wants to move to
    // If there is a wall, don't move the player
    // Use the Unwalkable layer to check
    bool CheckGrid(Transform tTransform, Vector3 v3Check)
    {
        bool bCheck = true;

        return bCheck;
    }

	// Update is called once per frame
	void Update () 
    {
        // If no key is pressed, check if there is any movement
        // If no movement, can move by pressing key
        isMoving = false;

        // Movement Controls
        if (!isMoving)
        {
            Vector3 v3Position = this.transform.position;

            if (Input.GetKeyDown("w"))
            {
                if (gGrid.CheckGridSpace(v3Position, Vector3.forward) == true)
                {
                    transform.Translate(Vector3.forward);
                    isMoving = true;
                }
            }

            if (Input.GetKeyDown("s"))
            {
                if (gGrid.CheckGridSpace(v3Position, Vector3.back) == true)
                {
                    transform.Translate(Vector3.back);
                    isMoving = true;
                }
            }

            if (Input.GetKeyDown("a"))
            {
                if (gGrid.CheckGridSpace(v3Position, Vector3.left) == true)
                {
                    transform.Translate(Vector3.left);
                    isMoving = true;
                }
            }

            if (Input.GetKeyDown("d"))
            {
                if (gGrid.CheckGridSpace(v3Position, Vector3.right) == true)
                {
                    transform.Translate(Vector3.right);
                    isMoving = true;
                }
            }
        }
	}
}
