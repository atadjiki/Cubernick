using HoloToolkit.Unity.Buttons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject resetButton;
    public GameObject lightSource;
    public GameObject musicOn;
    public GameObject musicOff;

    private bool buttonPressed = false;
    private bool currentState = false;

    System.Random randPitch;

    // Use this for initialization
    void Start()
    {
         randPitch = new System.Random();
    }
	
	// Update is called once per frame
	void Update () {

        bool state = resetButton.GetComponent<CompoundButtonToggle>().State;
        
        if(currentState != state)
        {
            currentState = state;

            if (state == true)
            {
                lightSource.SetActive(false);
                Debug.Log("Button Pressed: " + resetButton.GetComponent<CompoundButtonToggle>().State);

            }
            else if (state == false)
            {
                lightSource.SetActive(true);
                Debug.Log("Button Pressed: " + resetButton.GetComponent<CompoundButtonToggle>().State);
            }

            switchSong();
        }
    }
    
    void switchSong()
    {
        if (currentState)
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
