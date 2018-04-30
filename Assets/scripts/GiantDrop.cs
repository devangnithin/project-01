using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantDrop : MonoBehaviour {
    //private CharacterController charControl;
    private bool moveUp = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(this.transform.localPosition.y < 10);
        //Debug.Log(this.transform.localPosition.y);

        if (moveUp) transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        if (!moveUp) transform.Translate(Vector3.up * Time.deltaTime*-10, Space.World);

        if (this.transform.localPosition.y > 10)
        {
            moveUp = false;

        }

        if (this.transform.localPosition.y < 0.3)
        {
            moveUp = true;
        }

    }
}
