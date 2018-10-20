using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoneyDisplay : MonoBehaviour
{

	public Text moneyText;
	GameObject playerV;// = GameObject.Find("PlayerObject");
	Player player; //= playerV.GetComponent <Player>();
	
	// Use this for initialization
	void Start () {
		playerV = GameObject.Find("PlayerObject");
		player = playerV.GetComponent <Player>();
		//setMoney();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
}
