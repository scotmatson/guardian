using UnityEngine;
using System.Collections;

public class LightRotate : MonoBehaviour {

    public bool rotateRight = true;
	public float rotateSpeed;

	// Use this for initialization
	void Start () {
		rotateSpeed = 200.0F;
	}
	
	// Update is called once per frame
	void Update () {
        if (rotateRight)    //Rotate right
            transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);
        else                //Rotate left
            transform.Rotate(Vector3.down, Time.deltaTime * rotateSpeed);
	}
}
