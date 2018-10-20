using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_control : MonoBehaviour {
    public double mouseSensitivity = .01;
    public Vector3 position;
    public Camera myCamera;
    public double scrollValue = .25;
    public int refPixPerUnit = 100;
    public float maxHeight = 5f;
    public float maxWidth=8;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        float halfHeight = myCamera.orthographicSize;
        float halfWidth = myCamera.aspect * halfHeight;
        maxWidth = myCamera.aspect * maxHeight;
        if (Input.GetMouseButtonDown(0))
        {
             position=Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
           
            Vector3 delta = position - Input.mousePosition;
            maxHeight = 5f;
            float maxWdith = 10f;
            transform.Translate((float)(delta.x * mouseSensitivity), (float)(delta.y * mouseSensitivity), 0);
            position = Input.mousePosition;
            if ((myCamera.gameObject.transform.position.y) > maxHeight)
            {
                Vector3 newPos = new Vector3(myCamera.gameObject.transform.position.x, maxHeight);
                newPos.z= myCamera.gameObject.transform.position.z;
                myCamera.gameObject.transform.SetPositionAndRotation(newPos, (myCamera.gameObject.transform.rotation));
            }
            if ((myCamera.gameObject.transform.position.y) < -1*maxHeight)
            {
                Vector3 newPos = new Vector3(myCamera.gameObject.transform.position.x, -1*maxHeight);
                newPos.z = myCamera.gameObject.transform.position.z;
                myCamera.gameObject.transform.SetPositionAndRotation(newPos, (myCamera.gameObject.transform.rotation));
            }
            if ((myCamera.gameObject.transform.position.x) > maxWdith)
            {
                Vector3 newPos = new Vector3(maxWdith, myCamera.gameObject.transform.position.y);
                newPos.z = myCamera.gameObject.transform.position.z;
                myCamera.gameObject.transform.SetPositionAndRotation(newPos, (myCamera.gameObject.transform.rotation));
            }
            if ((myCamera.gameObject.transform.position.x) < -1* maxWdith)
            {
                Vector3 newPos = new Vector3(-1* maxWdith, myCamera.gameObject.transform.position.y);
                newPos.z = myCamera.gameObject.transform.position.z;
                myCamera.gameObject.transform.SetPositionAndRotation(newPos, (myCamera.gameObject.transform.rotation));
            }
        }

        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            if (myCamera.orthographicSize > .25)
            {
                myCamera.orthographicSize = (float)(myCamera.orthographicSize - scrollValue);
            }
        }
        else if (d < 0f)
        {
            if (myCamera.orthographicSize < 5)
            {
                myCamera.orthographicSize = (float)(myCamera.orthographicSize + scrollValue);

            }
        }
    }
    
 
}
