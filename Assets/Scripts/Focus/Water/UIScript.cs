using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public CanvasGroup darkToLight;
    public Image imageAlt;
    public GameObject panelLoading;
    public Image loadingBar;

    #region GamePlay Objects
    public GameObject environment1;
    public AudioSource audioSource;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        LoadingPanel();
    }

    private void LoadingPanel()
    {
        loadingBar.DOFillAmount(1,5).OnComplete(DartToLight);                         
    }

    private void DartToLight()
    {
        panelLoading.SetActive(false);
        //darkToLight.GetComponent<RectTransform>().DOScaleX(0f, 7f);
        darkToLight.DOFade(0, 10f).OnComplete(StartGamePlay);         // Karanliktan aydinliga acilma suresi
    }

    private void StartGamePlay() 
    {
        environment1.SetActive(true);
    }



}
