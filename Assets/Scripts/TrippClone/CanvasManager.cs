using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Main Menu Script for UI Objects
public class CanvasManager : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject sunImage;                 // -100,200 e git
    public GameObject moodImage;                //  100,200 e git

    public GameObject imageR, imageG, imageY;

    public GameObject panelUser;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loading());
    }

    private void Update()
    {
        
    }

    IEnumerator Loading()
    {
        sunImage.GetComponent<Image>().DOFade(1f,3f);
        sunImage.transform.GetChild(0).GetComponent<Image>().DOFade(1f,3f);
        moodImage.GetComponentInChildren<Image>().DOFade(1f, 3f);
        moodImage.transform.GetChild(0).GetComponent<Image>().DOFade(1f, 3f);

        yield return new WaitForSeconds(2f);
        introPanel.GetComponent<Image>().DOFade(1f, 5f).OnComplete(IntroTurning); 
    }

    private void IntroTurning()
    {
        introPanel.GetComponent<Image>().DOFade(0,2f);
        introPanel.GetComponent<RectTransform>().DORotate(new Vector3(0,0,180f),2f).OnComplete(LevelImages);

        Vector2 sunPos = new Vector2(-400,200);
        Vector2 moonPos = new Vector2(400,200);

        sunImage.GetComponent<RectTransform>().DOAnchorPos(sunPos, 2f);
        moodImage.GetComponent<RectTransform>().DOAnchorPos(moonPos, 2f);
    }

    private void LevelImages()
    {
        imageR.SetActive(true);
        imageG.SetActive(true);
        imageY.SetActive(true);

        imageR.GetComponent<Image>().DOFade(1f,2f);
        imageG.GetComponent<Image>().DOFade(1f,2f);
        imageY.GetComponent<Image>().DOFade(1f,2f);

        imageR.transform.GetChild(0).GetComponent<TMP_Text>().DOFade(1f, 2f);
        imageG.transform.GetChild(0).GetComponent<TMP_Text>().DOFade(1f, 2f);
        imageY.transform.GetChild(0).GetComponent<TMP_Text>().DOFade(1f, 2f);
        ActivatePanelUser();
    }

    private void ActivatePanelUser()
    {
        panelUser.GetComponent<RectTransform>().DOScale(1f,2f);
    }

    // OnClick
    public void GoSelectedLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    
}
