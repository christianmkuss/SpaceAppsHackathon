using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noCloneGenMoney : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    GameObject refObj;
    Player refScript;
    public void onclick()
    {
        refObj = GameObject.Find("PlayerObject");
        refScript = refObj.GetComponent<Player>();
        refScript.money += Random.Range(5,11);

        Debug.Log("good");
        Destroy(gameObject);
    }
}
