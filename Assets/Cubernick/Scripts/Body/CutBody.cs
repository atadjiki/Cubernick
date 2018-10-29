using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutBody : MonoBehaviour {

    public int i_ID;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BreakThisBodyPart()
    {
        BodyController _tempCtrl = transform.parent.GetComponent<BodyController>();
        // go to world space
        transform.parent = null;
        _tempCtrl.InitBodyParts();

        OnOffGrabFunction(true);
    }

    void OnOffGrabFunction(bool _OnOrOff)
    {
        transform.GetComponent<HoloToolkit.Unity.InputModule.Examples.Grabbables.ThrowableObject>().enabled = _OnOrOff;
        transform.GetComponent<HoloToolkit.Unity.InputModule.Examples.Grabbables.GrabbableChild>().enabled = _OnOrOff;
        Rigidbody rb = transform.GetComponent<Rigidbody>();
        Destroy(transform.GetComponent<SpringJoint>());
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
