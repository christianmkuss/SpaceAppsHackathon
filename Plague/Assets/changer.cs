using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changer : MonoBehaviour {
    public Slider factory;
    public Button m_YourFirstButton, m_YourSecondButton;

    void Start()
    {
        Button btn1 = m_YourFirstButton.GetComponent<Button>();
        Button btn2 = m_YourSecondButton.GetComponent<Button>();

        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        btn1.onClick.AddListener(Increment);
        btn2.onClick.AddListener(Decrement);                                 
    }

    void Increment()
    {
        factory.value = Mathf.MoveTowards(factory.value, 10, 1);
    }

    void Decrement()
    {
        factory.value = Mathf.MoveTowards(factory.value, 0, 1);
    }
}
