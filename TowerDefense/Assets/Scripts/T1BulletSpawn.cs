using UnityEngine;
using System.Collections;

public class T1BulletSpawn : MonoBehaviour
{

    public GameObject BulletRef;
    public float ShootingFreq ;

    public GameObject ParentGameObject ;


    private float _nextShot;

    private bool delayShot;

	// Use this for initialization
	void Start ()
	{
        //This gets the TwinPrefab Obeject it is Game Objects up
	    ParentGameObject = transform.parent.gameObject.transform.gameObject.transform.parent.gameObject;

        BulletRef = Resources.Load<GameObject>("Ammo/TwinPrefab");


        //Initalize if they are not 
	    ShootingFreq = (ShootingFreq == 0) ? 1.0f : ShootingFreq;
	    
        //Delay first shot 
        _nextShot = 0;

	    delayShot = true;

	}
	
	// Update is called once per frame
	void Update ()
	{


	    if (ParentGameObject.GetComponent<Turret>().HasTarget)
	    {

	        //Used to delay the turret enough to spin
	        if (delayShot)
	        {
	            delayShot = false;
	            return;
	        }

	        if (Time.time > _nextShot)
	        {
	            _nextShot = Time.time + ShootingFreq;
	            Instantiate(BulletRef, transform.position, transform.rotation);
	        }

	    }
	    else
	    {
	        delayShot = true;
	    }

	}
}
