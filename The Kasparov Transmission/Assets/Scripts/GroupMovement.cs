using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnumNamespace 
{
	public enum MoveDirection 
	{
		Forward,
		Back,
		Left,
		Right,
		Invalid
	}
}


// GroupMovement:
//	Step all bodies in a group based on the direction of movement.
//  Stepping priority is assigned to members of the group for correct inter-group collisions
//	Stepping priority is higher for members that are furthest in the travelling direction.
//		aka Leftmost group member will step left first.

public class GroupMovement : MonoBehaviour {

	EnumNamespace.MoveDirection m_ePassedDirection = EnumNamespace.MoveDirection.Invalid;

	public static EnumNamespace.MoveDirection ConvertV3ToDirection(Vector3 v3Direction) 
	{
		EnumNamespace.MoveDirection eDirection = EnumNamespace.MoveDirection.Invalid;
		if (v3Direction == Vector3.forward) 
		{
			eDirection = EnumNamespace.MoveDirection.Forward;
		} 
		else if ( v3Direction == Vector3.back ) 
		{
			eDirection = EnumNamespace.MoveDirection.Back;
		}
		else if ( v3Direction == Vector3.left )
		{
			eDirection = EnumNamespace.MoveDirection.Left;
		}
		else if ( v3Direction == Vector3.right )
		{
			eDirection = EnumNamespace.MoveDirection.Right;
		}
		return eDirection;
	}

	public static Vector3 ConvertDirectionToV3( EnumNamespace.MoveDirection eDirection ) 
	{
		Vector3 v3Return = Vector3.zero;
		switch( eDirection ) 
		{
			case EnumNamespace.MoveDirection.Forward:
				v3Return = Vector3.forward;
				break;
			case EnumNamespace.MoveDirection.Back:
				v3Return = Vector3.back;
				break;
			case EnumNamespace.MoveDirection.Left:
				v3Return = Vector3.left;
				break;
			case EnumNamespace.MoveDirection.Right:
				v3Return = Vector3.right;
				break;
		}
		return v3Return;
	}

	//This method takes an array of game objects and sorts them by an axis measurement.
	//The returned array is the sorted version with respect to direction.
	public GameObject[] GetGroupMovementList(List<GameObject> goGroupMembers, EnumNamespace.MoveDirection eDirection) 
	{
		m_ePassedDirection = eDirection;

		//N.B. C# '=' is shallow copy. Pass by value parameter makes this safe.
		GameObject[] goSteppingOrder = goGroupMembers.ToArray();
		System.Array.Sort(goSteppingOrder, PositionComparison );

		if ( eDirection == EnumNamespace.MoveDirection.Back || eDirection == EnumNamespace.MoveDirection.Left ) 
		{
			System.Array.Reverse( goSteppingOrder );
		}
		return goSteppingOrder;
	}

	//Debug function to output the names of the group in order.
	public static void PrintGroup( GameObject[] agoGroupMembers ) 
	{
		string strOutputString = "";
		for( int iLoop = 0; iLoop < agoGroupMembers.Length; ++iLoop ) 
		{
			strOutputString = strOutputString + " " + agoGroupMembers[iLoop].name;
		}
		Debug.Log(strOutputString);
	}


	//Method compares two gameobjects by position, axis result based on direction.
	//Direction results in axis selection aka passing 'Forward' is functionally equivalent to 'Back'.
	//N.B If a null is passed we give 0 as there should be no sorting action.
	//If a is LT b, then -ve. If a is EQ b, then 0, If a is GT, then +ve.
	private int PositionComparison(GameObject a, GameObject b) 
	{
		if ( a == null || b == null ) 
		{
			//Ignore
			return 0;
		}

		float aPos = 1.0f;
		float bPos = 1.0f;

		switch( m_ePassedDirection ) 
		{
			case EnumNamespace.MoveDirection.Forward:
			case EnumNamespace.MoveDirection.Back:
				aPos = a.transform.position.z;
				bPos = b.transform.position.z;
				break;
			case EnumNamespace.MoveDirection.Left:
			case EnumNamespace.MoveDirection.Right:
				aPos = a.transform.position.x;
				bPos = b.transform.position.x;
				break;
		}

		//Default float comparison
		return (aPos.CompareTo( bPos ) * -1);
	}
}
