using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public float speed; //Speed of the projectile

	// Use this for initialization
	void Start ()
	{
	    speed = (speed == 0) ? 3 : speed;

	}
	
	// Update is called once per frame
	void Update ()
	{
	    var newPos = transform.forward*speed;
	    transform.position = newPos;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
