using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_WSA && UNITY_2017_2_OR_NEWER
using UnityEngine.XR.WSA.Input;
#endif

public class GameManager : MonoBehaviour {

    //on collision, this zone will flag body parts as hidden
    public List<GameObject> bodyParts = new List<GameObject>();
    private int hiddenCount;
    private bool bodyHidden = false;
    public GameObject UItext;
    public GameObject playerCamera;
    private bool crouched = false;
    public float crouchAmount = 1;
    public int crouchCooldown = 60;
    private int currentCooldown = 0;

    // Use this for initialization
    void Start () {

        hiddenCount = bodyParts.Count;
        UItext.GetComponent<TextMesh>().text = "" + hiddenCount;
	}
	
	// Update is called once per frame
	void Update () {

        currentCooldown++;

        if (Input.GetButton("CONTROLLER_LEFT_STICK_CLICK") && currentCooldown > crouchCooldown)
           {
            Debug.Log("Joystick Pressed");
            currentCooldown = 0;
            if (crouched)
            {
                crouched = false;
                playerCamera.transform.position += new Vector3(0, crouchAmount, 0);
            }
            else
            {
                crouched = true;
                playerCamera.transform.position += new Vector3(0, -crouchAmount, 0);

            }


        }
		
	}

    public void decrementCount()
    {
        if (!bodyHidden)
        {
            hiddenCount--;
            UItext.GetComponent<TextMesh>().text = "" + hiddenCount;

            if (hiddenCount == 0)
            {
                bodyHidden = true;
            }
        }
        

    }
}
