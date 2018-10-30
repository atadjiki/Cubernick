using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPoionter : MonoBehaviour {
    [SerializeField]  private float f_maxDetectDist;
    [SerializeField] private float f_maxRadius;
    private float f_currDetectDist  =0;
    private  SphereCollider sc_detector;
    [SerializeField] LayerMask mask;

    [SerializeField] private bool b_lightOn;
    private bool b_triggerDown;
    [SerializeField] GameObject meshOfLight;
	// Use this for initialization
	void Start () {
        sc_detector = GetComponent<SphereCollider>();
        TurnOnOffLight(false);
    }
	
	// Update is called once per frame
	void Update () {
        DebugDraw();
        if(b_lightOn)
            RayCastToShowObject();

        if (!b_triggerDown && Input.GetAxis("CONTROLLER_LEFT_TRIGGER") > 0)
        {
            b_triggerDown = true;
            Debug.Log("Trigger Down");
            TurnOnOffLight(!b_lightOn);
        }
        if (Input.GetAxis("CONTROLLER_LEFT_TRIGGER") == 0)
            b_triggerDown = false;
    }

    public void TurnOnOffLight(bool _bON)
    {
        b_lightOn = _bON;
        if (b_lightOn)
        {
            // turn on light
            transform.GetChild(0).gameObject.SetActive(true);
            sc_detector.enabled = true;
            meshOfLight.SetActive(true);
        }
        else
        {
            // turn off light
            transform.GetChild(0).gameObject.SetActive(false);
            sc_detector.enabled = false;
            meshOfLight.SetActive(false);
        }
    }

    GameObject RayCastToShowObject()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit, f_maxDetectDist, mask))
        {
            f_currDetectDist = Vector3.Distance(hit.point, transform.position);
            sc_detector.radius = 10f*f_maxRadius * f_currDetectDist / f_maxDetectDist;
            sc_detector.center = new Vector3(sc_detector.center.x, sc_detector.center.y, 10*f_currDetectDist);
            return hit.transform.gameObject;
        }
        else
        {
            f_currDetectDist = 0;
            sc_detector.center = new Vector3(sc_detector.center.x, sc_detector.center.y, f_maxDetectDist);
            sc_detector.radius = f_maxRadius;
        }

        return null;
    }
    void DebugDraw()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * f_currDetectDist, Color.red);
    }

  
}
