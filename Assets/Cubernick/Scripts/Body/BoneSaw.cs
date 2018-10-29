using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneSaw : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CutTrigger"))
        {
            CutBody _body = other.transform.parent.GetComponent<CutBody>();
            _body.BreakThisBodyPart();
            other.gameObject.SetActive(false);
        }
    }
}
