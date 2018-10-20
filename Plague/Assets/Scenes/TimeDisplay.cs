using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeDisplay : MonoBehaviour
{

	public float counter;
	public int month;
	public int year;
	public Text date;
	private Boolean flag = true;
	private float addToCount=1;
    //public GameObject player;
    // Use this for initialization
    void Awake ()
	{
        if (flag)
		{
			//DontDestroyOnLoad(this.gameObject);
			//initialize();
			flag = false;
		}
        setDate();
        
	}
	
	// Update is called once per frame
	void Update()
	{
		counter += addToCount;
		if ((int)counter >= 30)
		{
			month += 1;
		}

		if (month > 12)
		{
			year += 1;
		}

        counter = (int)counter % 30;
		month = month % 13;
		if (month == 0)
		{
			month = 1;
		}

		if (year > 2018)
		{
			SceneManager.LoadScene("LossScene");
		}

		setDate();
	}


	void setDate()
	{
		date.text = month.ToString() + ", " + year.ToString();
	}

	void initialize()
	{
		counter = 0;
		month = 1;
		year = 1958;
	}
    public void setIncrement(float amount)
    {
        addToCount = amount;
    }
}
