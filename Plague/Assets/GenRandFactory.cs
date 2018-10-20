using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GenRandFactory : MonoBehaviour {
    public GameObject factory;
    public GameObject noCloneFactory;
    public int temp = 1;
    public GameObject worldMap;
    public Slider factorySlider;
    Random rnd = new Random();
    int count = 0;
    int maxT = 0;
    // Update is called once per frame

	void Update () {
        Slider fact = factorySlider.GetComponent<Slider>();
        int value = (int)fact.value;
        if (value == temp)
        {
            temp++;
            spawnBag();
        }
        if(value == temp - 2)
        {
            temp--;
            deleteBag();
        }
	}
    
    void deleteBag()
    {
        GameObject go = GameObject.Find("noCloneFactory(Clone)");
        if (go)
        {
            Destroy(go.gameObject);
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
            if (System.Math.Round(col.r, 3) != 0.039 && System.Math.Round(col.g, 3) != 0.039 && System.Math.Round(col.b, 3) != 0.200)
            {
                Instantiate(noCloneFactory, loc, Quaternion.identity);
                break;
            }
        }


    }
}
/*
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GenRandFactory : MonoBehaviour {
    public GameObject factory;
    public GameObject nonReplicatingFactory;
    public int temp = 1;
    public GameObject worldMap;
    public Slider factorySlider;
    Random rnd = new Random();
    int count = 0;
    int maxT = 0;
    // Update is called once per frame

	void Update () {
        Slider fact = factorySlider.GetComponent<Slider>();
        int value = (int)fact.value;
        if (value == temp)
        {
            temp++;
            spawnBag();
        }
        if(value == temp - 2)
        {
            temp--;
            deleteBag();
        }
	}
    
    void deleteBag()
    {
        GameObject go = GameObject.Find("NonCloning(Clone)");
        if (go)
        {
            Destroy(go.gameObject);
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
            loc.z = -11;
            percBox.x = (loc.x - minVal.x) / rangeBox.x;
            percBox.y = (loc.y - minVal.y) / rangeBox.y;
            //float hg = image.width;
            Color col = image.GetPixel((int)(image.width * percBox.x), (int)(image.height * percBox.y));
            Debug.Log(col.r);
            if (System.Math.Round(col.r,3) != 0.039 && System.Math.Round(col.g, 3) != 0.039 && System.Math.Round(col.b, 3) != 0.200)
            {
                Instantiate(nonReplicatingFactory, loc, Quaternion.identity);
                break;
            }
        }
       

    }
}
*/