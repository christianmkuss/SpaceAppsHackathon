using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenRandMoney : MonoBehaviour {
    public GameObject bag_money;
    public GameObject worldMap;
    
    Random rnd = new Random();
    int count = 0;
    int maxT = 0;
    // Update is called once per frame
	void Update () {
        if (count == 0)
        {
            maxT = Random.Range(600, 901);
        }
        count++;
		if (count == maxT)
        {
            count = 0;
            spawnBag();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Destroy(gameObject);
                print("Destroyed money at " + Input.mousePosition);
            }
        }
	}
    
    void spawnBag()
    {
        
        Renderer rend = worldMap.GetComponent<Renderer>();
        Vector3 loc;
        
        Texture2D image = Resources.Load("worldMap") as Texture2D;
        Vector2 minVal;
        minVal.x = rend.bounds.min.x;
        minVal.y = rend.bounds.min.y;
        Vector2 maxVal;
        maxVal.x = rend.bounds.max.x;
        maxVal.y = rend.bounds.max.y;
        Vector2 rangeBox;
        rangeBox.x = maxVal.x - minVal.x;
        rangeBox.y = maxVal.y - minVal.y;
        Vector2 percBox;

        while (true)
        {
            loc.x = Random.Range(rend.bounds.min.x, rend.bounds.max.x);
            loc.y = Random.Range(rend.bounds.min.y, rend.bounds.max.y);
            loc.z = 0;
            percBox.x = (loc.x - minVal.x) / rangeBox.x;
            percBox.y = (loc.y - minVal.y) / rangeBox.y;
            //float hg = image.width;
            Color col = image.GetPixel((int)(image.width * percBox.x), (int)(image.height * percBox.y));
            //Debug.Log(col.ToString());
            if (System.Math.Round(col.r,3) != 0.039 && System.Math.Round(col.g, 3) != 0.039 && System.Math.Round(col.b, 3) != 0.200)
            {
                GameObject clone = Instantiate(bag_money, loc, Quaternion.identity) as GameObject;
                clone.transform.SetParent(bag_money.transform.parent);
                break;
            }
        }
       
        
    }
    GameObject refObj;
    Player refScript;
    public void onclick()
    {
        Debug.Log("good");
        Destroy(gameObject);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
