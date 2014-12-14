using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public float Speed;

	// Use this for initialization
	void Start ()
	{

	    Speed = (Speed == 0) ? .5f : Speed;

	}
	
	// Update is called once per frame
	void Update ()
	{


	    var newPos = transform.forward*Speed;
	    transform.position += newPos;

	    if (!renderer.isVisible)
	    {
	        Destroy(gameObject);
	    }

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Calls the method DoDamage on all MonoBehaviours(Scripts) attached to this GameObject
            other.gameObject.SendMessage("DoDamage", 1);

            //Destroy the Missile
            Destroy(gameObject);
        }
    }

}
