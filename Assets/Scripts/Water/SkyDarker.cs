using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkyDarker : MonoBehaviour
{
    public float time = 60000;         // 60000 is good if speed = 75
    public int speed = 75;            // 
    public Transform sunTransform;
    public Light sun;

    // Update is called once per frame
    void Update()
    {
        ChangeTime();
    }


    private void ChangeTime()
    {
        time += Time.deltaTime * speed;

        if (time > 86400)
        {
            time = 0;
        }

        sunTransform.rotation = Quaternion.Euler(new Vector3((time - 21600) / 86400 * 360, 90f, 0f));

    }
}
