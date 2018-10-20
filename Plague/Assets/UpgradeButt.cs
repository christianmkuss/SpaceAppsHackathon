using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeButt : MonoBehaviour
{
    public GameObject upgrade, panel;

    public void Upgrade()
    {
        upgrade.SetActive(true);
        panel.SetActive(false);
        
    }
    
    
    
}
