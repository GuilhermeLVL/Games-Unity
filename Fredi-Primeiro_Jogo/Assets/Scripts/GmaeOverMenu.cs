using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GmaeOverMenu : MonoBehaviour
{

    private void OnEnable()
    {
        var rectTransform = GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(0, rectTransform.rect.height);

        rectTransform.LeanMoveY(0, 1f);

    }

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
