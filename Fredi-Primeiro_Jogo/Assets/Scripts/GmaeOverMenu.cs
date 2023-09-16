using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GmaeOverMenu : MonoBehaviour
{

    private LTDescr RestartAnimation;

    [SerializeField]
    private TMPro.TextMeshProUGUI higScore;

    private void OnEnable()
    {

        higScore.text = $"High Score: {GameManager.Instance.HighScore}";


        var rectTransform = GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(0, rectTransform.rect.height);

        rectTransform.LeanMoveY(0, 1f).setEaseOutElastic().delay = 0.5f;

        if (RestartAnimation is null) { 
        
         RestartAnimation =  GetComponentInChildren<TMPro.TextMeshProUGUI>().gameObject.LeanScale(new Vector3(1.2f, 1.2f), 0.3f).setLoopPingPong();
        }
        RestartAnimation.resume();

    }

    public void Restart()
    {
        RestartAnimation.pause();
        gameObject.SetActive(false);
        GameManager.Instance.Enabled();
    }

    public void Quit()
    {
        Application.Quit();
    }
   
}
