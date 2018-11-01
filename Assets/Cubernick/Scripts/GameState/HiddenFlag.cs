using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit;
using HoloToolkit.Unity.InputModule.Examples.Grabbables;

public class HiddenFlag : MonoBehaviour {

    public bool hidden = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setHidden()
    {

        Debug.Log("Setting Hidden: " + this.name);
        this.gameObject.SetActive(false);

    }

    public void setUnHidden()
    {
        hidden = false;
    }
}
