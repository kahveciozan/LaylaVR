using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

// Class that opens the buttons when interacting with the picture to select the chapters
public class IntractOnImage : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).GetComponent<Image>().DOFade(1f,0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).GetComponent<Image>().DOFade(0f, 0.5f);
    }

   
}
