using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMain : MonoBehaviour
{
    public GameObject upgrade, panel;

    public void Panel()
    {
        upgrade.SetActive(false);
        panel.SetActive(true);
    }
}
