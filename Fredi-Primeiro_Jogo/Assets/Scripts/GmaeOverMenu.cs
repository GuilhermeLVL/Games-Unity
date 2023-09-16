using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmaeOverMenu : MonoBehaviour
{
    private LTDescr restAnimation = null;
    private void OnEnable()
    {
        
       

        var rectTranform = GetComponent<RectTransform>();
        rectTranform.anchoredPosition = new Vector2(0,rectTranform.rect.height);

        rectTranform.LeanMoveY(0, 1f).setEaseOutElastic().delay = 0.5f;
        if (restAnimation is null) 
        {
           GetComponentInChildren<TMPro.TextMeshProUGUI>().gameObject.LeanScale(new Vector3(1.2f, 1.2f), 0.3f).setLoopPingPong(); 
        }
        restAnimation.resume();
    }

    public void Restart()
    {
        restAnimation.pause();
        gameObject.SetActive(false);
        GameManager.Instance.Enabled();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
