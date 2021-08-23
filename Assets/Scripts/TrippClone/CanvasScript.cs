using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public GameObject localAvatar;
    public GameObject laser;
    public GameObject particles;
    public GameObject glowing;
    public GameObject player;

    public Image loadingImage;
    //public Camera camera;
    public GameObject panelLoadig;
    public GameObject panelEmoji;
    public GameObject panelRate;
    public CanvasGroup darkToLight;
    public GameObject finishRatePanel;

    private int playerSpeedX = 0;
    private int playerSpeedY = 0;
    private int playerSpeedZ = 0;

    public ParticleSystem ripple;
    public Camera cam;
    public GameObject water;
    public ParticleSystem teleportEffect;
    public Material skybox2;
    public GameObject secondSection;
    public GameObject breatingExercise;


    // Start is called before the first frame update
    void Start()
    {
        LoadingBarProgress();
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position += new Vector3(0,playerSpeedY*Time.deltaTime,playerSpeedZ*Time.deltaTime);
    }


    private void LoadingBarProgress()
    {
        loadingImage.DOFillAmount(1f,8f).OnComplete(OpenEmojiPanel);
    }

    private void OpenEmojiPanel()
    {
        panelLoadig.SetActive(false);
        panelEmoji.SetActive(true);
    }


    public void OnClickDoneButton() 
    {
        panelEmoji.SetActive(false);
        panelRate.SetActive(true);
    }


    public void OnClickRate()
    {
        panelRate.SetActive(false);
        localAvatar.SetActive(false);
        laser.SetActive(false);
        darkToLight.DOFade(0, 15f).OnComplete(StartTheGame);
    }

    private void StartTheGame()
    {
        particles.SetActive(true);
        StartCoroutine(Glowing());
        StartCoroutine(Rising());
    }

    IEnumerator Glowing()
    {
        yield return new WaitForSeconds(20f);       // 20 
        glowing.SetActive(true);
    }

    //Teleportation Effect and Rising
    IEnumerator Rising()
    {
        //TO DO Sound Teleportation

        //yield return new WaitForSeconds(55f);
        //teleportEffect.Play();
        yield return new WaitForSeconds(55f);       //55
        playerSpeedY = 1;
        yield return new WaitForSeconds(5f);        // 5
        darkToLight.DOFade(1f,5).OnComplete(InitSecondPart);
    }
    
    private void InitSecondPart()
    {
        water.SetActive(false);
        playerSpeedY = 0;
        playerSpeedZ = 10;
        //RenderSettings.skybox = skybox2;
        glowing.SetActive(false);
        particles.SetActive(false);

        secondSection.SetActive(true);
        player.transform.position = new Vector3(0,1000,0);
        darkToLight.DOFade(0f,15f).OnComplete(() => StartCoroutine(InitSecondPart2()));
    }

    IEnumerator InitSecondPart2()
    {
        yield return new WaitForSeconds(15f);
        playerSpeedZ = 0 ;
        yield return new WaitForSeconds(5f);
        SecondPart();
    }
 
    private void SecondPart()
    {
        //ripple.Play(); 
        breatingExercise.transform.localScale = new Vector3(0, 0, 0);

        breatingExercise.SetActive(true);
        breatingExercise.transform.DOScale(1f,10f);
        StartCoroutine(FinishGame());
    }


    IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(40f);
        breatingExercise.transform.DOScale(0f,5f).OnComplete(() => darkToLight.DOFade(1f,5f).OnComplete(ActivateFİnishPanel));
    }

    private void ActivateFİnishPanel()
    {
        finishRatePanel.SetActive(true);
        localAvatar.SetActive(true);
        laser.SetActive(true);
    }




    #region AfterFinish
    public void OnClickFinishRate(int rate)
    {
        finishRatePanel.GetComponent<Image>().DOFade(0f,1f).OnComplete(() => SceneManager.LoadScene(0));
    }



    #endregion
}
