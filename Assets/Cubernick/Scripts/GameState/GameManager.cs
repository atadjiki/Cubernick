using HoloToolkit.Unity.Buttons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject resetButton;
    public GameObject lightSource;
    public GameObject music;

    System.Random randPitch;

    // Use this for initialization
    void Start()
    {
         randPitch = new System.Random();
    }
	
	// Update is called once per frame
	void Update () {
		
        if(resetButton.GetComponent<CompoundButtonToggle>().State == true)
        {
            lightSource.SetActive(false);
            Debug.Log("Button Pressed: " + resetButton.GetComponent<CompoundButtonToggle>().State);
        }
       else if (resetButton.GetComponent<CompoundButtonToggle>().State == false)
        {
            lightSource.SetActive(true);
            Debug.Log("Button Pressed: " + resetButton.GetComponent<CompoundButtonToggle>().State);
        }

    }
    
    void scramblePitch()
    {

        music.GetComponent<AudioSource>().pitch = (float) (randPitch.NextDouble() * (1.2 - 0.5) + 0.5);
    }
}
