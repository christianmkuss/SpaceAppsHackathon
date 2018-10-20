using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float money;
	public int factoryCount;
	public double cO2;
	public int farms;
	public int nrg;
    public int awa;
    public double lossRate;
    public int counter;
    public static List<double> tempList = new List<double>();

    public Slider factory, NRG, farm, awareness, co2Level, temp;
	public Text moneyText;
    public Text co2value;

    // Use this for initialization
    void Start () {
        lossRate = .95;
        money = 1000;
        factoryCount = 0;
        cO2 = 315;
        farms = 0;
        nrg = 0;
        awa = 0;
	    
	}
	
	// Update is called once per frame
	void Update () {
        Slider fact = factory.GetComponent<Slider>();
        Slider energy = NRG.GetComponent<Slider>();
        Slider moo = farm.GetComponent<Slider>();
        Slider aware = awareness.GetComponent<Slider>();
        Slider cO2lev = co2Level.GetComponent<Slider>();
        Slider temperature = temp.GetComponent<Slider>();

		if (money >= 0)
		{
			if (factoryCount < (int) fact.value)
			{
				money += 30 * (factoryCount - fact.value);
			}

			if (nrg < (int) energy.value)
			{
				money += 15 * (nrg - energy.value);
			}

			if (farms < (int) moo.value)
			{
				money += 6 * (farms - moo.value);
			}
		}

        factoryCount = (int)fact.value;
        awa = (int)aware.value;
        farms = (int)moo.value;
        nrg = (int)energy.value;
        if(counter >= 360)
        {
	        
	        
            counter %= 360;
	        if (money < 0)
	        {
		        factoryCount = (int) Mathf.MoveTowards(factoryCount, 0, 1);
		        factory.value = (float) factoryCount;
		        farms = (int) Mathf.MoveTowards(farms, 0, 1);
		        farm.value = (float) farms;
		        nrg = (int) Mathf.MoveTowards(nrg, 0, 1);
		        NRG.value = (float) nrg;
		        cO2 *= lossRate;
                tempList.Add((double)temperature.value);
	        }
	        else
	        {
		        getCarbon();
		        getMoney();
	        }

	        money += 2;
        }
		
        counter++;
		setMoney();
        temperature.value = (float)(1.666 * Math.Log(cO2 / 315));
        co2value.text = ((int)cO2).ToString() + " ppm";
        cO2lev.value = (float)cO2;
		if (cO2 > (double)500)
		{
			SceneManager.LoadScene("EndScene");
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("EndScene"));
		}
	}

    public void getCarbon()
    {
        cO2 += factoryCount * 8 + nrg * 3 + farms * 2;
        cO2 *= lossRate;
    }

	public void getMoney()
	{
		money += factoryCount * 5	 + nrg * 2 + farms;
	}
	
	void setMoney()
	{
		moneyText.text = "$ " + money.ToString();
	}
}