using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardCamera : MonoBehaviour {

	private float screenWidth;
	private float screenHeight;
	public Vector3 cameraMove;
	public double scale;
	
	// Use this for initialization
	void Start ()
	{
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		//cameraMove.x = transform.position.x;
		//cameraMove.y = transform.position.y;
		//cameraMove.z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update ()
	{
		keyboardCamera();
	}

	void keyboardCamera()
	{
		//cameraMove = 
		if (Input.GetKey("up"))
		{
			transform.Translate(0, (float)scale, 0);
		}
		if (Input.GetKey("down"))
		{
			transform.Translate(0, (float)-scale, 0);
		}
		if (Input.GetKey("left"))
		{
			transform.Translate((float)-scale, 0, 0);
		}
		if (Input.GetKey("right"))
		{
			transform.Translate((float)scale, 0, 0);
		}

		//transform.position = cameraMove;
	}
}
