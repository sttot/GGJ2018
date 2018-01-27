using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileControl : MonoBehaviour {

	public bool IsHole = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MakeHole()
	{
		IsHole = true;
		gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		gameObject.GetComponent<Rigidbody> ().useGravity = true;
	}

	public void SetColor(Color col)
	{
		GetComponent<MeshRenderer> ().material.color = col;
	}

	public void OnCollisionStay(Collision col)
	{
		if (IsHole) 
		{
			if (col.collider.gameObject.tag == "Player") 
			{
				col.collider.gameObject.SetActive (false);
			}
		}
	}
}
