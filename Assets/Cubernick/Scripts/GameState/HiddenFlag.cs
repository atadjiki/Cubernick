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
        hidden = true;
        foreach (Renderer child in this.gameObject.GetComponentsInChildren<Renderer>())
        {
            child.material.color = Color.green;
        }

        foreach (GrabbableChild child in this.gameObject.GetComponentsInChildren<GrabbableChild>())
        {
            child.enabled = false;
        }

        foreach (ThrowableObject child in this.gameObject.GetComponentsInChildren<ThrowableObject>())
        {
            child.enabled = false;
        }

    }

    public void setUnHidden()
    {
        hidden = false;
    }
}
