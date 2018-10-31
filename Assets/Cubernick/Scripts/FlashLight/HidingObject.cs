using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingObject : MonoBehaviour {

    public bool bHiding;
    private MeshRenderer[] tr_Meshes;
	// Use this for initialization
	void Start () {
        tr_Meshes = transform.GetComponentsInChildren<MeshRenderer>();
        OnAndOff(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnAndOff(bool _bOn)
    {
        bHiding = !_bOn;
        if (bHiding)
        {
            foreach (var item in tr_Meshes)
            {
                item.transform.gameObject.SetActive(false);
            }
        }
        else
            foreach (var item in tr_Meshes)
            {
                item.transform.gameObject.SetActive(true);
            }

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
