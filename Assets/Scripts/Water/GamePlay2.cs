using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GamePlay2 : MonoBehaviour
{
    public Light directionalLight;
    public GameObject player;
    private int playerSpeedZ = 0;
    public CanvasGroup darkToLight;

    public Material skyboxSpace;

    public AudioSource soundBG;
    public GameObject planet3;
    public GameObject planet2;

    public ParticleSystem glow;

    public ParticleSystem inhale, exhale, hold;
    public GameObject inhaleForceFied;
    public GameObject glowForceField;
    public ParticleSystem stars;
    public float tempSize = 0;

    // Start is called before the first frame update
    void Start()
    {
        inhaleForceFied.SetActive(false);
        InitSpaceLevel();
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position += new Vector3(0, 0, playerSpeedZ * Time.deltaTime);

    }


    private void InitSpaceLevel()
    {
        stars.Play();
        playerSpeedZ = 10;
        player.transform.position = new Vector3(0,100,0);
        directionalLight.transform.rotation = Quaternion.Euler(50,-30,0);
        RenderSettings.skybox = skyboxSpace;

        StartCoroutine(VolumeUp());
        darkToLight.DOFade(0.8f, 7f).OnComplete(()=> darkToLight.DOFade(0f,7f));                    // Duzelt daha geç aydinlansin
        planet3.transform.DOScale(20f,50f);
        planet2.transform.DOScale(80f,20f);

        StartCoroutine(FocusEffect());
    }


    IEnumerator VolumeUp()
    {
        for(int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(1f);
            soundBG.volume += 0.025f;
        }
        
    }


    IEnumerator FocusEffect()
    {
        yield return new WaitForSeconds(120f);   // 120s ------------------------------------------------
        glowForceField.SetActive(true);
        playerSpeedZ = 0;
        glow.Play();


        yield return new WaitForSeconds(10f);        //5s

        for (int i = 0; i< 30; i++)
        {
            yield return new WaitForSeconds(1f);
            tempSize += 0.4f;
            var v = glow.main;
            v.startSize = new ParticleSystem.MinMaxCurve(tempSize-3, tempSize + 3f);
        }

        glowForceField.SetActive(false);
        inhaleForceFied.SetActive(true);
        stars.Stop();


        yield return new WaitForSeconds(15f);
        StartCoroutine(VirtualBreathings());

    }


    IEnumerator VirtualBreathings()
    {
        inhale.gameObject.SetActive(true);
        exhale.gameObject.SetActive(true);
        hold.gameObject.SetActive(true);

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(5f);
            // TO DO INHALE SOUND
            inhale.Play();
            yield return new WaitForSeconds(5f);
            // TO DO HOLD SOUND
            hold.Play();
            yield return new WaitForSeconds(5f);
            // TO DO EXHALE SOUND
            exhale.Play();
            yield return new WaitForSeconds(5f);
            // TO DO HOLD SOUND
            hold.Play();
        }

        inhale.gameObject.SetActive(false);
        exhale.gameObject.SetActive(false);
        hold.gameObject.SetActive(false);

    }


}
