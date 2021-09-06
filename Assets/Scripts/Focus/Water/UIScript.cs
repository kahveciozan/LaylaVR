using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public CanvasGroup darkToLight;
    public GameObject panelLoading;
    public Image loadingBar;
    public GameObject panelMoodTracker;
    public GameObject panelRating;
    public GameObject panelFinish;

    #region GamePlay Objects
    public GameObject environment1;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        LoadingPanel();
    }

    private void LoadingPanel()
    {
        loadingBar.DOFillAmount(1,5).OnComplete(OpenMoodTracker);                         
    }
    private void OpenMoodTracker()
    {
        panelLoading.SetActive(false);
        panelMoodTracker.SetActive(true);
    }

    public void MoodTrackerOnClick()
    {
        panelMoodTracker.SetActive(false);
        panelRating.SetActive(true);
    }

    public void RatingOnClick()
    {
        panelRating.SetActive(false);
        DartToLight();
    }

    private void DartToLight()
    {
        darkToLight.DOFade(0, 10f).OnComplete(StartGamePlay);         // Karanliktan aydinliga acilma suresi
    }

    

    private void StartGamePlay() 
    {
        environment1.SetActive(true);
    }

}
