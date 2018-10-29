using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{


    List<Rigidbody> rb_bodyParts = new List<Rigidbody>();
    List<SpringJoint> sj_bodyConnects = new List<SpringJoint>();

    // if false, set isKinematic is false
    [SerializeField] bool b_AffectByPhysic;
    // Use this for initialization
    void Start()
    {

        // init list
        InitBodyParts();

        SetPhysic(b_AffectByPhysic);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPhysic(bool _Affect)
    {
        foreach (var item in rb_bodyParts)
        {
            item.isKinematic = !_Affect;
            item.useGravity = _Affect;
        }

    }
    public void InitBodyParts()
    {
        sj_bodyConnects = new List<SpringJoint>();
        rb_bodyParts = new List<Rigidbody>();

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<SpringJoint>() != null)
            {
                // sj depends on rb, so there should be rb when there is sj
                rb_bodyParts.Add(transform.GetChild(i).GetComponent<Rigidbody>());
                sj_bodyConnects.Add(transform.GetChild(i).GetComponent<SpringJoint>());
                transform.GetChild(i).GetComponent<CutBody>().i_ID = i;
            }
        }
    }
}
