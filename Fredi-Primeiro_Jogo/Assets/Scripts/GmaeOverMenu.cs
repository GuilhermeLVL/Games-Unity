using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmaeOverMenu : MonoBehaviour
{
   
    public void Restart()
    {

        gameObject.SetActive(false);
        GameManager.Instance.Enabled();
    }

    public void Quit()
    {

    }
}
