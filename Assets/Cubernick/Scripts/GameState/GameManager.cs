using HoloToolkit.Unity.Buttons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject resetButton;
    public GameObject startPosition;
    public GameObject Managers;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(resetButton.GetComponent<CompoundButtonToggle>().State == true)
        {
            Managers.GetComponent<Transform>().
                SetPositionAndRotation(startPosition.GetComponent<Transform>().position, startPosition.GetComponent<Transform>().rotation);
        }

	}
}
