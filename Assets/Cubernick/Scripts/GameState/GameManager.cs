using HoloToolkit.Unity.Buttons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject resetButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(resetButton.GetComponent<CompoundButtonToggle>().State == true)
        {
            SceneManager.UnloadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

	}
}
