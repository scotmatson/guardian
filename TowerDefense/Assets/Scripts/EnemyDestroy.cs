using UnityEngine;
using System.Collections;

public class EnemyDestroy : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //If the enemy reaches the end of the path it should be destroyed and player
        //base should take damage
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
