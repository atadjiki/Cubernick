using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        foreach(Renderer child in this.gameObject.GetComponentsInChildren<Renderer>())
        {
            child.material.color = Color.green;
        }
    }

    public void setUnHidden()
    {
        hidden = false;
    }
}
