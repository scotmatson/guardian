using UnityEngine;
using System.Collections;

public class T1BulletSpawn : MonoBehaviour
{

    public GameObject BulletRef;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        Instantiate(BulletRef, transform.position, transform.rotation);
	    }

	}
}
