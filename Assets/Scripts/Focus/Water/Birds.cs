using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    //private ParticleSystem ps;
    public GameObject forcefield;

    public AudioSource soundFx;

    public ParticleSystem birds1, birds2;

    // Start is called before the first frame update
    void Start()
    {
        //ps = GetComponent<ParticleSystem>();
        StartCoroutine(BurstCountArttir());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BurstCountArttir()
    {
        yield return new WaitForSeconds(15f);
        birds1.maxParticles = 5;
        birds2.maxParticles = 5;
        soundFx.Play();

        yield return new WaitForSeconds(15f);
        birds1.maxParticles = 10;
        birds2.maxParticles = 10;
        soundFx.Play();

        yield return new WaitForSeconds(15f);
        birds1.maxParticles = 15;
        birds2.maxParticles = 15;
        forcefield.SetActive(true);
        birds1.startLifetime = 20f;
        birds2.startLifetime = 20f;
        soundFx.Play();

        yield return new WaitForSeconds(15f);
        birds1.maxParticles = 20;
        birds2.maxParticles = 20;
        soundFx.Play();

        yield return new WaitForSeconds(15f);
        birds1.maxParticles = 25;
        birds2.maxParticles = 25;

        yield return new WaitForSeconds(15f);
        birds1.maxParticles = 30;
        birds2.maxParticles = 30;
    }
}
