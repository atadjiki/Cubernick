using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleContainer : MonoBehaviour {
    [SerializeField] int i_LockID;
    private Transform tr_SnapPosition;
    [Header("Rotation Quest")]
    // if this puzzle require the rotation correct
    [SerializeField] bool b_RotQuest;
    // the error that allow player to have
    [SerializeField] float f_RotThreshold;
    [SerializeField] int i_AnswerDir;   // 0, up, 1, right, 2, down, 3. left
    private int i_degree;
    private Puzzle thePuzzle;
    private bool b_snapping;
    // if the rotation match
    bool b_RotMatch;
	// Use this for initialization
	void Start () {
        tr_SnapPosition = transform.GetChild(1);
        i_degree = i_AnswerDir * 90;
    }
	
	// Update is called once per frame
	void Update () {
        if (b_snapping && thePuzzle!=null)
        {
            if(Vector3.Distance(thePuzzle.transform.position, tr_SnapPosition.position) >0.03f)
            {
                thePuzzle.transform.position = Vector3.Lerp(thePuzzle.transform.position, tr_SnapPosition.position, 2*Time.deltaTime);
                //Vector3 destRot = new Vector3(i_AnswerDir * 90, thePuzzle.transform.eulerAngles.y, thePuzzle.transform.eulerAngles.z);
                //thePuzzle.transform.eulerAngles = Vector3.Lerp(thePuzzle.transform.eulerAngles, destRot, 2 * Time.deltaTime);
            }
            else
            {
                b_snapping = false;
                thePuzzle.b_puzzleFinished = true;
            }
        }

        if(b_RotQuest && thePuzzle != null && !b_RotMatch)
        {
            float dotValue = Vector3.Dot(tr_SnapPosition.up, thePuzzle.transform.up);
            float angleBetween = Vector3.SignedAngle(tr_SnapPosition.up, thePuzzle.transform.up, Vector3.left);
            //Debug.Log(dotValue + " " + angleBetween);
            int dir = -1;
            if (dotValue > 0 && ((angleBetween > 0 &&angleBetween < f_RotThreshold) || (angleBetween <0 && angleBetween > -f_RotThreshold)))
                dir = 0;
            if (angleBetween > 90 - f_RotThreshold && angleBetween < 90 + f_RotThreshold)
                dir = 1;
            if (dotValue < 0 &&((angleBetween > -180 && angleBetween < -180 + f_RotThreshold) || (angleBetween < 180 && angleBetween > 180 - f_RotThreshold) ))
                dir = 2;
            if (angleBetween < -90 + f_RotThreshold && angleBetween > -90 - f_RotThreshold)
                dir = 3;


            if (dir == i_AnswerDir)
                b_RotMatch = true;
            if (b_RotMatch)
            {
                SnapObjectIn();
            }
        }
	}

    void SnapObjectIn()
    {
        b_snapping = true;
        //
        //  add the code here to let the object get rid of the control from hand!
        //  ....
    }

    private void OnTriggerEnter(Collider other)
    {
        Puzzle temp = other.GetComponent<Puzzle>();
        if(temp!=null && temp.i_PuzzleID == i_LockID && !temp.b_puzzleFinished)
        {
            Debug.Log("Puzzle enter");
            thePuzzle = temp;
            if (!b_RotQuest)
                SnapObjectIn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Puzzle>() == thePuzzle)
        {
            thePuzzle = null;
        }
    }
}
