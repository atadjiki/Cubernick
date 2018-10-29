using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //on collision, this zone will flag body parts as hidden
    public List<GameObject> bodyParts = new List<GameObject>();
    private int hiddenCount;
    private bool bodyHidden = false;

    // Use this for initialization
    void Start () {

        hiddenCount = bodyParts.Count;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void decrementCount()
    {
        if (!bodyHidden)
        {
            hiddenCount--;

            if (hiddenCount == 0)
            {
                bodyHidden = true;
            }
        }
        

    }
}
