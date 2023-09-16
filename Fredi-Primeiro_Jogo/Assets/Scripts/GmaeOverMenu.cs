using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GmaeOverMenu : MonoBehaviour
{
    public void Restart()
    {
        gameObject.SetActive(false);
        GameManager.Instance.Enabled();
    }

    public void Quit()
    {
        Application.Quit();
    }
   
}
