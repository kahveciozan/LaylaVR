using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class InteractLevelSelect : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.GetChild(0).GetComponent<RectTransform>().DOScale(1f,0.2f);                   // LevelText
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().DOColor(Color.yellow, 1f);
        transform.DOScale(1.2f,1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetChild(0).GetComponent<RectTransform>().DOScale(0.6f, 0.2f);                   // LevelText
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().DOColor(Color.white, 1f);
        transform.DOScale(0.9f, 1f);

    }

}
