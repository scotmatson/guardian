using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public float Speed;

	// Use this for initialization
	void Start ()
	{

	    Speed = (Speed == 0) ? .2f : Speed;

	}
	
	// Update is called once per frame
	void Update ()
	{

	    var newPos = transform.forward*Speed;
	    transform.position += newPos;

	}
}
