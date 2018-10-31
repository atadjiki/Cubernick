using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotator : MonoBehaviour
{

    [SerializeField] bool b_canRot;
    [SerializeField] float rot_Spd;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (b_canRot)
            transform.Rotate(0, rot_Spd * Time.deltaTime, 0);
    }
}
