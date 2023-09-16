using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private RectTransform scoreReactTransform;

    private void Start()
    {
        scoreReactTransform.anchoredPosition = new Vector2 (scoreReactTransform.anchoredPosition.x,0 );
        GetComponentInChildren<TMPro.TextMeshProUGUI>().gameObject.LeanScale(new Vector3(1.2f, 1.2f), 0.3f).setLoopPingPong();
    }
    public void Play()
    {
        GetComponent<CanvasGroup>().LeanAlpha(0, 0.2f).setOnComplete(onComplete);
      
    }

    private void onComplete()
    {

        scoreReactTransform.LeanMoveY(-72, 0.75f).setEaseOutBounce();
        gameManager.Enabled();
        Destroy(gameObject);
    }
}
