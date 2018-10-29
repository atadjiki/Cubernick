﻿using HoloToolkit.Unity.Buttons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public GameObject lightSwitchButton;
    public GameObject resetButton;
    public GameObject lightSource;
    public GameObject musicOn;
    public GameObject musicOff;

    private bool lightSwitchPressed = false;
    private bool currentLightSwitchState = false;
    private int lightSwitchPressCount = 0;

    private bool resetPressed = false;
    private bool currentResetState = false;

    System.Random randPitch;

    // Use this for initialization
    void Start()
    {
         randPitch = new System.Random();
    }
	
	// Update is called once per frame
	void Update () {

        bool lightSwitchState = lightSwitchButton.GetComponent<CompoundButtonToggle>().State;
        
        if(currentLightSwitchState != lightSwitchState)
        {
            currentLightSwitchState = lightSwitchState;
            lightSwitchPressCount++;

            if (lightSwitchState == true)
            {
                lightSource.SetActive(false);
                Debug.Log("Light Switch Pressed: " + lightSwitchState);

            }
            else if (lightSwitchState == false)
            {
                lightSource.SetActive(true);
                Debug.Log("Light Switch Pressed: " + lightSwitchState);
            }

            if(lightSwitchPressCount % 5 == 0)
            {
                switchSong();
            }
            
        }

        bool resetState = resetButton.GetComponent<CompoundButtonToggle>().State;

        if (currentResetState != resetState)
        {
            currentResetState = resetState;

            if (resetState == true)
            {
                Debug.Log("Reset Button Pressed: " + resetState);
                Application.Quit();
            }
            else if (resetState == false)
            {
                Debug.Log("Reset Button Pressed: " + resetState);
            }
        }
    }
    
    void switchSong()
    {
        if (currentLightSwitchState)
        {
            musicOn.GetComponent<AudioSource>().mute = false;
            musicOff.GetComponent<AudioSource>().mute = true;
        }
        else 
        {
            musicOn.GetComponent<AudioSource>().mute = true;
            musicOff.GetComponent<AudioSource>().mute = false;
        }
    }
}
