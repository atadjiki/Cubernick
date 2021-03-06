﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingZone : MonoBehaviour {

    public Material before;
    public Material after;
    public GameObject requires;

	// Use this for initialization
	void Start () {
        
        if(before != null)
            setMaterial(before);
		
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered hiding zone collision: " + this.name);

        if (requires != null && collision.gameObject != requires)
        {
            Debug.Log("Not the correct body part");
            return;
        }

        if(collision.gameObject.GetComponent<HiddenFlag>() != null  && !collision.gameObject.GetComponent<HiddenFlag>().hidden)
        {
            Debug.Log("Body part hidden" + collision.gameObject.name);
            collision.gameObject.GetComponent<HiddenFlag>().setHidden(); //hide the body part
            GameObject.Find("GameManager").GetComponent<GameManager>().decrementCount(); //decrement body count
            if(after!=null) setMaterial(after);

            if(this.gameObject.GetComponent<HidingObject>() != null)
            {
                this.gameObject.GetComponent<HidingObject>().enabled = false;
            }
        }
    }

    private void setMaterial(Material material)
    {

        foreach(Renderer child in this.gameObject.GetComponentsInChildren<Renderer>())
        {
            child.material = material;
        }
    }


}
