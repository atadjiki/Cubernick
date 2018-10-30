using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingZone : MonoBehaviour {

    public Material before;
    public Material after;
    public GameObject requires;

	// Use this for initialization
	void Start () {

        setMaterial(before);
		
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered hiding zone collision: " + this.name);

        if(requires != null && collision.gameObject != requires)
        {
            return;
        }

        if(collision.gameObject.GetComponent<HiddenFlag>() != null  && !collision.gameObject.GetComponent<HiddenFlag>().hidden)
        {
            Debug.Log("Body part hidden" + collision.gameObject.name);
            collision.gameObject.GetComponent<HiddenFlag>().setHidden(); //hide the body part
            GameObject.Find("GameManager").GetComponent<GameManager>().decrementCount(); //decrement body count
            setMaterial(after);
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
