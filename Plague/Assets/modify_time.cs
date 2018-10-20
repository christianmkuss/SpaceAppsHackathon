using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class modify_time : MonoBehaviour {
    public void changeTimestate(float newTime)
    {
        Time.timeScale = newTime;
    }
}
