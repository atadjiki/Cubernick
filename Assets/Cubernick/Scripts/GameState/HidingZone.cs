using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingZone : MonoBehaviour { 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<HiddenFlag>() != null)
        {
            Debug.Log("Body part hidden" + collision.gameObject.name);
            collision.gameObject.GetComponent<HiddenFlag>().setHidden();
            GameObject.Find("GameManager").GetComponent<GameManager>().decrementCount();
            this.gameObject.SetActive(false);
        }
    }


}
