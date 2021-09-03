using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GamePlay1 : MonoBehaviour
{
    public GameObject focusEffect;
    public GameObject starsWater;
    public GameObject birds;

    public ParticleSystem inhale, exhale, hold;


    public GameObject player;
    private int playerSpeedY = 0;
    private int focusSpeedY = 0;

    public CanvasGroup darkToLight;

    public GameObject water;
    public AudioSource soundBG;
    public GameObject environment1;
    public GameObject environment2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartFocusEffect());
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position += new Vector3(0, playerSpeedY*Time.deltaTime, 0);
        focusEffect.transform.position += new Vector3(0,focusSpeedY*Time.deltaTime,0);


        if(soundBG.volume < 0.3f)
        {
            soundBG.volume += Time.deltaTime/100;
        }
    }

    IEnumerator StartFocusEffect()
    {
        StartCoroutine(VirtualBreathings());    // Virtual Breathings start

        yield return new WaitForSeconds(120f);  //120   


        // Start to Focus Effect
        birds.SetActive(false);
        starsWater.GetComponent<ParticleSystem>().Stop();
        focusEffect.SetActive(true);

        yield return new WaitForSeconds(120);    //120

        // Stop focus effect
        focusSpeedY = 1;

        // Stop Focus Effect force field
        focusEffect.transform.GetChild(0).gameObject.SetActive(false);

        yield return new WaitForSeconds(5f);
        // TO DO Finish Sound effect
        playerSpeedY = 2;
        LightToDark();
    }

    

    IEnumerator VirtualBreathings()
    {
        inhale.gameObject.SetActive(true);
        exhale.gameObject.SetActive(true);
        hold.gameObject.SetActive(true);

        for(int i = 0; i < 5; i++)
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


    private void LightToDark()
    {
        soundBG.volume = 0.1f;
        darkToLight.DOFade(1f,15f).OnComplete(FinishWaterLevel);
    }

    private void FinishWaterLevel()
    {
        // Light acilarini düzelt
        playerSpeedY = 0;
        focusEffect.SetActive(false);
        water.SetActive(false);

        environment2.SetActive(true);
        environment1.SetActive(false);

    }
}
