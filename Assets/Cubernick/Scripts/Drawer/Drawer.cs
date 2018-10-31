using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour {

    [SerializeField] GameObject objInDrawer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DrawerDest"))
        {
            other.gameObject.SetActive(false);
            objInDrawer.SetActive(true);
            objInDrawer.transform.parent = null;
        }
    }
}
