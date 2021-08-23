using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterFlyMovement : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(speed*Time.deltaTime,0,0);
        transform.RotateAround(transform.position, new Vector3(0f, -1f, 0f), 90f * Time.deltaTime/15);
    }
}
