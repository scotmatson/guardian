using UnityEngine;
using System.Collections;

public class EnemyDestroy : MonoBehaviour {

    public GameObject MyGameObject;
    AudioSource shipExplosion;

	// Use this for initialization
	void Start () {
        shipExplosion = GetComponent<AudioSource>();
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
            //Not very resuseable since you have to drag objects from the editor - but this will cause
            //an explosion particle effect at the point of impact with a ship. Cool!
            Instantiate(MyGameObject, other.transform.position, other.transform.rotation);
            AudioSource.PlayClipAtPoint(shipExplosion.clip, transform.position);
            Destroy(other.gameObject);
        }
    }
}
