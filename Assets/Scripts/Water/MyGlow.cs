using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyGlow : MonoBehaviour
{
    private ParticleSystem ps;
    public ParticleSystem psC;

    Color32 color;
    private float alfa=0.0001f;
    private float r, g, b;
    private bool isFade15,isfade30, isFade100;


    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        //psC = GetComponentInChildren<ParticleSystem>();
        r = psC.startColor.r;
        g = psC.startColor.g;
        b = psC.startColor.b;

        StartCoroutine(TimeControl());
    }

    // Update is called once per frame
    void Update()
    {
        if (isFade15)
        {
            Fade15();
        }
        else if (isfade30)
        {
            Fade30();
        }
        else if (isFade100)
        {
            Fade100();
        }
            
        Debug.Log(alfa);
    }

    private void Fade15()
    {
        if (alfa <= 0.15)
        {
            alfa += alfa * Time.deltaTime / 4;
            color = new Color(r, g, b, alfa);
            psC.startColor = color;
            ps.startColor = color;

        }
    }


    private void Fade30()
    {
        if (alfa <= 0.3)
        {
            alfa += alfa * Time.deltaTime/4;
            color = new Color(r, g, b, alfa);
            psC.startColor = color;
            ps.startColor = color;

        }
    }

    private void Fade100()
    {
        if (alfa <= 1)
        {
            alfa += alfa * Time.deltaTime/4;
            color = new Color(r, g, b, alfa);
            psC.startColor = color;
            ps.startColor = color;
        }
    }


    IEnumerator TimeControl()
    {

        yield return new WaitForSeconds(20f);  // 60
        isFade15 = true;

        yield return new WaitForSeconds(60f);  // 60
        isfade30 = true;
        isFade15 = false;

        yield return new WaitForSeconds(20f);  //20
        isfade30 = false;
        isFade100 = true;


        yield return new WaitForSeconds(20f);    //20
        particles.SetActive(true);

    }
}
