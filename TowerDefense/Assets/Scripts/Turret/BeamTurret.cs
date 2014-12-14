using UnityEngine;
using System.Collections;

public class BeamTurret : MonoBehaviour
{


    public bool BeamExists;

    public GameObject beam;

	// Use this for initialization
	void Start () {
	

        

	}
	
	// Update is called once per frame
	void Update () {
	    



	}


    void Shoot()
    {
        Instantiate(beam, transform.position, transform.rotation);
        BeamExists = true;
    }

    void OnMouseDown()
    {
        Shoot();
    }


}
