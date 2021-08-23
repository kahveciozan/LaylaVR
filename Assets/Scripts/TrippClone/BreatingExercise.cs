using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class BreatingExercise : MonoBehaviour
{
    public TMP_Text breathText;
    public RectTransform movingCircle;
    public Image cyan, yellow, red, purple;

    public ParticleSystem exhalePS,  holdPS;
    private bool isExhale, isInhale = true, isHold;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer<10) return;

        RotatingCircle();
       

    }

    private void RotatingCircle()
    {
        movingCircle.RotateAround(movingCircle.position, new Vector3(0f, 0f, -1f), 10f * Time.deltaTime);

        float tempAngle = movingCircle.eulerAngles.z;

        if (tempAngle < 360 && tempAngle > 270)
        {
            cyan.DOFade(0.25f, 2f);
            yellow.DOFade(1f, 2f);
            breathText.text = "INHALE";
            Inhale();
        }
        else if (tempAngle < 270 && tempAngle > 180)
        {
            yellow.DOFade(0.25f, 2f);
            purple.DOFade(1f, 2f);
            breathText.text = "HOLD";
            Hold();
        }
        else if (tempAngle < 180 && tempAngle > 90)
        {
            purple.DOFade(0.25f, 2f);
            red.DOFade(1f, 2f);
            breathText.text = "EXHALE";
            Exhale();
        }
        else if (tempAngle < 90 && tempAngle > 0)
        {
            red.DOFade(0.25f, 2f);
            cyan.DOFade(1f, 2f);
            breathText.text = "HOLD";
            Hold();
        }
        else
        {
            Debug.Log("ELSE GIRDI");
        }
    }

    private void Exhale()
    {
        if (isExhale)
        {
            isExhale = false;
            isHold = true;
            isInhale = true;
            exhalePS.Play();
            //inhalePS.Stop();
            holdPS.Stop();
        }

    }

    private void Inhale()
    {
        if (isInhale)
        {
            isInhale = false;
            isHold = true;
            isExhale = true;
            //inhalePS.Play();
            holdPS.Stop();
            exhalePS.Stop();
        } 

    }

    private void Hold()
    {
        if (isHold)
        {
            isHold = false;
            isExhale = true;
            isInhale = true;
            holdPS.Play();
            //inhalePS.Stop();
            exhalePS.Stop();
        }
        
    }


}
