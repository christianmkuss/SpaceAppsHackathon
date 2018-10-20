using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class value : MonoBehaviour {
    public Slider slider;
    public Button m_YourFirstButton, m_YourSecondButton;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        slider.value = Mathf.MoveTowards(slider.value, .1f, 0.15f);
    }
}
