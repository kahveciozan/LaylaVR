using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseFocus : MonoBehaviour
{

    private ParticleSystem ps;
    private float tempSize = 0;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        StartCoroutine(IncreaseGlow());
    }

    IEnumerator IncreaseGlow()
    {
        yield return new WaitForSeconds(5f);

        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(1f);
            tempSize += 0.15f;
            var v = ps.main;
            v.startSize = new ParticleSystem.MinMaxCurve(0, tempSize);
        }


        
    }
}
