using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingObject : MonoBehaviour {

    public bool bHiding;
    private Transform tr_Meshes;
	// Use this for initialization
	void Start () {
        tr_Meshes = transform.GetChild(0);
        tr_Meshes.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnAndOff(bool _bOn)
    {
        bHiding = !_bOn;
        if (bHiding)
            tr_Meshes.gameObject.SetActive(false);
        else
            tr_Meshes.gameObject.SetActive(true);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FlashLight"))
        {
            OnAndOff(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FlashLight"))
        {
            OnAndOff(false);
        }
    }
}
