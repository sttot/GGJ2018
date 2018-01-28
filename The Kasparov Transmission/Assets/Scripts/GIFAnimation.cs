using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIFAnimation : MonoBehaviour {

	public Texture2D[] frames;
	public float framesPerSecond = 10.0f;

	void Update()
	{
		float value = Time.time * framesPerSecond;
		int index = (int) value;
		index = index % frames.Length;
		gameObject.GetComponent<Renderer>().material.mainTexture = frames[index];
	}
}
